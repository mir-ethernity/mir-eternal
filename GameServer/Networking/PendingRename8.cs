using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using GameServer.Maps;
using GameServer.Data;

namespace GameServer.Networking
{
	// Token: 0x0200024E RID: 590
	public sealed class 客户网络
	{
		// Token: 0x06000356 RID: 854 RVA: 0x0001CFCC File Offset: 0x0001B1CC
		public 客户网络(TcpClient 客户端)
		{
			
			this.剩余数据 = new byte[0];
			this.接收列表 = new ConcurrentQueue<GamePacket>();
			this.发送列表 = new ConcurrentQueue<GamePacket>();
			
			this.当前连接 = 客户端;
			this.当前连接.NoDelay = true;
			this.接入时间 = MainProcess.当前时间;
			this.断开时间 = MainProcess.当前时间.AddMinutes((double)CustomClass.掉线判定时间);
			this.断网事件 = (EventHandler<Exception>)Delegate.Combine(this.断网事件, new EventHandler<Exception>(NetworkServiceGateway.断网回调));
			this.网络地址 = this.当前连接.Client.RemoteEndPoint.ToString().Split(new char[]
			{
				':'
			})[0];
			this.开始异步接收();
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0001D090 File Offset: 0x0001B290
		public void 处理数据()
		{
			try
			{
				if (!this.正在断开 && !NetworkServiceGateway.网络服务停止)
				{
					if (MainProcess.当前时间 > this.断开时间)
					{
						this.尝试断开连接(new Exception("网络长时间无回应, 断开连接."));
					}
					else
					{
						this.处理已收封包();
						this.发送全部封包();
					}
				}
				else if (!this.正在发送 && this.接收列表.Count == 0 && this.发送列表.Count == 0)
				{
					PlayerObject PlayerObject = this.绑定角色;
					if (PlayerObject != null)
					{
						PlayerObject.玩家角色下线();
					}
					AccountData AccountData = this.绑定账号;
					if (AccountData != null)
					{
						AccountData.账号下线();
					}
					NetworkServiceGateway.移除网络(this);
					this.当前连接.Client.Shutdown(SocketShutdown.Both);
					this.当前连接.Close();
					this.接收列表 = null;
					this.发送列表 = null;
					this.当前阶段 = GameStage.正在登录;
				}
				else
				{
					this.处理已收封包();
					this.发送全部封包();
				}
			}
			catch (Exception ex)
			{
				if (this.绑定角色 != null)
				{
					string[] array = new string[10];
					array[0] = "处理网络数据时出现异常, 已断开对应连接\r\n账号:[";
					int num = 1;
					AccountData AccountData2 = this.绑定账号;
					string text;
					if (AccountData2 != null)
					{
						if ((text = AccountData2.账号名字.V) != null)
						{
							goto IL_113;
						}
					}
					text = "无";
					IL_113:
					array[num] = text;
					array[2] = "]\r\n角色:[";
					int num2 = 3;
					PlayerObject PlayerObject2 = this.绑定角色;
					string text2;
					if (PlayerObject2 != null)
					{
						if ((text2 = PlayerObject2.对象名字) != null)
						{
							goto IL_139;
						}
					}
					text2 = "无";
					IL_139:
					array[num2] = text2;
					array[4] = "]\r\n网络地址:[";
					array[5] = this.网络地址;
					array[6] = "]\r\n物理地址:[";
					array[7] = this.物理地址;
					array[8] = "]\r\n错误提示:";
					array[9] = ex.Message;
					MainProcess.添加系统日志(string.Concat(array));
				}
				PlayerObject PlayerObject3 = this.绑定角色;
				if (PlayerObject3 != null)
				{
					PlayerObject3.玩家角色下线();
				}
				AccountData AccountData3 = this.绑定账号;
				if (AccountData3 != null)
				{
					AccountData3.账号下线();
				}
				NetworkServiceGateway.移除网络(this);
				Socket client = this.当前连接.Client;
				if (client != null)
				{
					client.Shutdown(SocketShutdown.Both);
				}
				TcpClient tcpClient = this.当前连接;
				if (tcpClient != null)
				{
					tcpClient.Close();
				}
				this.接收列表 = null;
				this.发送列表 = null;
				this.当前阶段 = GameStage.正在登录;
			}
		}

		// Token: 0x06000358 RID: 856 RVA: 0x000037BF File Offset: 0x000019BF
		public void 发送封包(GamePacket 封包)
		{
			if (!this.正在断开 && !NetworkServiceGateway.网络服务停止 && 封包 != null)
			{
				this.发送列表.Enqueue(封包);
			}
		}

		// Token: 0x06000359 RID: 857 RVA: 0x000037DF File Offset: 0x000019DF
		public void 尝试断开连接(Exception e)
		{
			if (!this.正在断开)
			{
				this.正在断开 = true;
				EventHandler<Exception> eventHandler = this.断网事件;
				if (eventHandler == null)
				{
					return;
				}
				eventHandler(this, e);
			}
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0001D298 File Offset: 0x0001B498
		private void 处理已收封包()
		{
			while (!this.接收列表.IsEmpty)
			{
				if (this.接收列表.Count > (int)CustomClass.封包限定数量)
				{
					this.接收列表 = new ConcurrentQueue<GamePacket>();
					NetworkServiceGateway.屏蔽网络(this.网络地址);
					this.尝试断开连接(new Exception("封包过多, 断开连接并限制登录."));
					return;
				}
                if (this.接收列表.TryDequeue(out GamePacket GamePacket))
                {
                    if (!GamePacket.封包处理方法表.TryGetValue(GamePacket.封包类型, out MethodInfo methodInfo))
                    {
                        this.尝试断开连接(new Exception("没有找到封包处理方法, 断开连接. 封包类型: " + GamePacket.封包类型.FullName));
                        return;
                    }
                    methodInfo.Invoke(this, new object[]
                    {
                        GamePacket
                    });
                }
            }
		}

		// Token: 0x0600035B RID: 859 RVA: 0x0001D344 File Offset: 0x0001B544
		private void 发送全部封包()
		{
			List<byte> list = new();
			while (!this.发送列表.IsEmpty)
			{
                if (this.发送列表.TryDequeue(out GamePacket GamePacket))
                {
                    list.AddRange(GamePacket.取字节());
                }
            }
			if (list.Count != 0)
			{
				this.开始异步发送(list);
			}
		}

		// Token: 0x0600035C RID: 860 RVA: 0x00003802 File Offset: 0x00001A02
		private void 延迟掉线时间()
		{
			this.断开时间 = MainProcess.当前时间.AddMinutes((double)CustomClass.掉线判定时间);
		}

		// Token: 0x0600035D RID: 861 RVA: 0x0001D390 File Offset: 0x0001B590
		private void 开始异步接收()
		{
			try
			{
				if (!this.正在断开 && !NetworkServiceGateway.网络服务停止)
				{
					byte[] array = new byte[8192];
					this.当前连接.Client.BeginReceive(array, 0, array.Length, SocketFlags.None, new AsyncCallback(this.接收完成回调), array);
				}
			}
			catch (Exception ex)
			{
				this.尝试断开连接(new Exception("异步接收错误 : " + ex.Message));
			}
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0001D410 File Offset: 0x0001B610
		private void 接收完成回调(IAsyncResult 异步参数)
		{
			try
			{
				if (!this.正在断开 && !NetworkServiceGateway.网络服务停止 && this.当前连接.Client != null)
				{
					Socket client = this.当前连接.Client;
					int num = (client != null) ? client.EndReceive(异步参数) : 0;
					if (num > 0)
					{
						this.接收总数 += num;
						NetworkServiceGateway.已接收字节数 += (long)num;
						Array src = 异步参数.AsyncState as byte[];
						byte[] dst = new byte[this.剩余数据.Length + num];
						Buffer.BlockCopy(this.剩余数据, 0, dst, 0, this.剩余数据.Length);
						Buffer.BlockCopy(src, 0, dst, this.剩余数据.Length, num);
						this.剩余数据 = dst;
						for (;;)
						{
							GamePacket GamePacket = GamePacket.取封包(this, this.剩余数据, out this.剩余数据);
							if (GamePacket == null)
							{
								break;
							}
							this.接收列表.Enqueue(GamePacket);
						}
						this.延迟掉线时间();
						this.开始异步接收();
					}
					else
					{
						this.尝试断开连接(new Exception("客户端断开连接."));
					}
				}
			}
			catch (Exception ex)
			{
				this.尝试断开连接(new Exception("封包构建错误, 错误提示: " + ex.Message));
			}
		}

		// Token: 0x0600035F RID: 863 RVA: 0x0001D53C File Offset: 0x0001B73C
		private void 开始异步发送(List<byte> 数据)
		{
			try
			{
				this.正在发送 = true;
				this.当前连接.Client.BeginSend(数据.ToArray(), 0, 数据.Count, SocketFlags.None, new AsyncCallback(this.发送完成回调), null);
			}
			catch (Exception ex)
			{
				this.正在发送 = false;
				this.发送列表 = new ConcurrentQueue<GamePacket>();
				this.尝试断开连接(new Exception("异步发送错误 : " + ex.Message));
			}
		}

		// Token: 0x06000360 RID: 864 RVA: 0x0001D5C0 File Offset: 0x0001B7C0
		private void 发送完成回调(IAsyncResult 异步参数)
		{
			try
			{
				int num = this.当前连接.Client.EndSend(异步参数);
				this.发送总数 += num;
				NetworkServiceGateway.已发送字节数 += (long)num;
				if (num == 0)
				{
					this.发送列表 = new ConcurrentQueue<GamePacket>();
					this.尝试断开连接(new Exception("发送回调错误!"));
				}
				this.正在发送 = false;
			}
			catch (Exception ex)
			{
				this.正在发送 = false;
				this.发送列表 = new ConcurrentQueue<GamePacket>();
				this.尝试断开连接(new Exception("发送回调错误 : " + ex.Message));
			}
		}

		// Token: 0x06000361 RID: 865 RVA: 0x0000381A File Offset: 0x00001A1A
		public void 处理封包(ReservedPacketZeroOnePacket P)
		{
		}

		// Token: 0x06000362 RID: 866 RVA: 0x0000381A File Offset: 0x00001A1A
		public void 处理封包(ReservedPacketZeroTwoPacket P)
		{
		}

		// Token: 0x06000363 RID: 867 RVA: 0x0000381A File Offset: 0x00001A1A
		public void 处理封包(ReservedPacketZeroThreePacket P)
		{
		}

		// Token: 0x06000364 RID: 868 RVA: 0x0001D664 File Offset: 0x0001B864
		public void 处理封包(上传游戏设置 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家更改设置(P.字节描述);
		}

		// Token: 0x06000365 RID: 869 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(客户碰触法阵 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x06000366 RID: 870 RVA: 0x0001D6B4 File Offset: 0x0001B8B4
		public void 处理封包(客户进入法阵 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家进入法阵(P.法阵编号);
		}

		// Token: 0x06000367 RID: 871 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(ClickNpcDialogPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x06000368 RID: 872 RVA: 0x0001D704 File Offset: 0x0001B904
		public void 处理封包(RequestObjectDataPacket P)
		{
			if (this.当前阶段 != GameStage.场景加载 && this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.请求对象外观(P.对象编号, P.状态编号);
		}

		// Token: 0x06000369 RID: 873 RVA: 0x0001D764 File Offset: 0x0001B964
		public void 处理封包(客户网速测试 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.发送封包(new InternetSpeedTestPacket
			{
				当前时间 = P.客户时间
			});
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0001D7B8 File Offset: 0x0001B9B8
		public void 处理封包(测试网关网速 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.发送封包(new LoginQueryResponsePacket
			{
				当前时间 = P.客户时间
			});
		}

		// Token: 0x0600036B RID: 875 RVA: 0x0000384D File Offset: 0x00001A4D
		public void 处理封包(客户请求复活 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家请求复活();
		}

		// Token: 0x0600036C RID: 876 RVA: 0x0001D80C File Offset: 0x0001BA0C
		public void 处理封包(ToggleAttackMode P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
            if (Enum.IsDefined(typeof(AttackMode), (int)P.AttackMode) && Enum.TryParse<AttackMode>(P.AttackMode.ToString(), out AttackMode 模式))
            {
                this.绑定角色.更改AttackMode(模式);
                return;
            }
            this.尝试断开连接(new Exception("更改AttackMode时提供错误的枚举参数.即将断开连接."));
		}

		// Token: 0x0600036D RID: 877 RVA: 0x0001D898 File Offset: 0x0001BA98
		public void 处理封包(更改PetMode P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
            if (Enum.IsDefined(typeof(PetMode), (int)P.PetMode) && Enum.TryParse<PetMode>(P.PetMode.ToString(), out PetMode 模式))
            {
                this.绑定角色.更改PetMode(模式);
                return;
            }
            this.尝试断开连接(new Exception(string.Format("更改PetMode时提供错误的枚举参数.即将断开连接. 参数 - {0}", P.PetMode)));
		}

		// Token: 0x0600036E RID: 878 RVA: 0x0000388A File Offset: 0x00001A8A
		public void 处理封包(上传角色位置 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家同步位置();
		}

		// Token: 0x0600036F RID: 879 RVA: 0x0001D934 File Offset: 0x0001BB34
		public void 处理封包(客户角色转动 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
            if (Enum.IsDefined(typeof(GameDirection), (int)P.转动方向) && Enum.TryParse<GameDirection>(P.转动方向.ToString(), out GameDirection 转动方向))
            {
                this.绑定角色.玩家角色转动(转动方向);
                return;
            }
            this.尝试断开连接(new Exception("玩家角色转动时提供错误的枚举参数.即将断开连接."));
		}

		// Token: 0x06000370 RID: 880 RVA: 0x0001D9C0 File Offset: 0x0001BBC0
		public void 处理封包(客户角色走动 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家角色走动(P.坐标);
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0001DA10 File Offset: 0x0001BC10
		public void 处理封包(客户角色跑动 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家角色跑动(P.坐标);
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0001DA60 File Offset: 0x0001BC60
		public void 处理封包(CharacterSwitchSkillsPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家开关技能(P.技能编号);
		}

		// Token: 0x06000373 RID: 883 RVA: 0x0001DAB0 File Offset: 0x0001BCB0
		public void 处理封包(CharacterEquipmentSkillsPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			if (P.技能栏位 < 32)
			{
				this.绑定角色.玩家拖动技能(P.技能栏位, P.技能编号);
				return;
			}
			this.尝试断开连接(new Exception("玩家装配技能时提供错误的封包参数.即将断开连接."));
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0001DB20 File Offset: 0x0001BD20
		public void 处理封包(CharacterReleaseSkillsPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家释放技能(P.技能编号, P.动作编号, P.目标编号, P.锚点坐标);
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0001DB80 File Offset: 0x0001BD80
		public void 处理封包(BattleStanceSwitchPacket P)
		{
			if (this.当前阶段 != GameStage.场景加载 && this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家切换姿态();
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0001DBD4 File Offset: 0x0001BDD4
		public void 处理封包(客户更换角色 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定账号.更换角色(this);
			this.当前阶段 = GameStage.选择角色;
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0001DC24 File Offset: 0x0001BE24
		public void 处理封包(场景加载完成 P)
		{
			if (this.当前阶段 != GameStage.场景加载 && this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家进入场景();
			this.当前阶段 = GameStage.正在游戏;
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0001DC7C File Offset: 0x0001BE7C
		public void 处理封包(ExitCurrentCopyPacket P)
		{
			if (this.当前阶段 != GameStage.场景加载 && this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家退出副本();
		}

		// Token: 0x06000379 RID: 889 RVA: 0x000038C7 File Offset: 0x00001AC7
		public void 处理封包(玩家退出登录 P)
		{
			if (this.当前阶段 == GameStage.正在登录)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定账号.返回登录(this);
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(打开角色背包 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x0600037B RID: 891 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(CharacterPickupItemsPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x0600037C RID: 892 RVA: 0x0001DCD0 File Offset: 0x0001BED0
		public void 处理封包(CharacterDropsItemsPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家丢弃物品(P.背包类型, P.物品位置, P.丢弃数量);
		}

		// Token: 0x0600037D RID: 893 RVA: 0x0001DD2C File Offset: 0x0001BF2C
		public void 处理封包(CharacterTransferItemPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家转移物品(P.当前背包, P.原有位置, P.目标背包, P.目标位置);
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0001DD8C File Offset: 0x0001BF8C
		public void 处理封包(CharacterUseItemsPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家使用物品(P.背包类型, P.物品位置);
		}

		// Token: 0x0600037F RID: 895 RVA: 0x0001DDE0 File Offset: 0x0001BFE0
		public void 处理封包(玩家喝修复油 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家喝修复油(P.背包类型, P.物品位置);
		}

		// Token: 0x06000380 RID: 896 RVA: 0x0001DE34 File Offset: 0x0001C034
		public void 处理封包(玩家扩展背包 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家扩展背包(P.背包类型, P.扩展大小);
		}

		// Token: 0x06000381 RID: 897 RVA: 0x0001DE88 File Offset: 0x0001C088
		public void 处理封包(RequestStoreDataPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.RequestStoreDataPacket(P.版本编号);
		}

		// Token: 0x06000382 RID: 898 RVA: 0x0001DED8 File Offset: 0x0001C0D8
		public void 处理封包(CharacterPurchageItemsPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家购买物品(P.商店编号, P.物品位置, P.购入数量);
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0001DF34 File Offset: 0x0001C134
		public void 处理封包(CharacterSellItemsPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家出售物品(P.背包类型, P.物品位置, P.卖出数量);
		}

		// Token: 0x06000384 RID: 900 RVA: 0x00003904 File Offset: 0x00001B04
		public void 处理封包(查询回购列表 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.请求回购清单();
		}

		// Token: 0x06000385 RID: 901 RVA: 0x0001DF90 File Offset: 0x0001C190
		public void 处理封包(CharacterRepurchageItemsPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			if (P.物品位置 < 100)
			{
				this.绑定角色.玩家回购物品(P.物品位置);
				return;
			}
			this.尝试断开连接(new Exception("玩家回购物品时提供错误的位置参数.即将断开连接."));
		}

		// Token: 0x06000386 RID: 902 RVA: 0x0001DFFC File Offset: 0x0001C1FC
		public void 处理封包(商店修理单件 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.商店修理单件(P.背包类型, P.物品位置);
		}

		// Token: 0x06000387 RID: 903 RVA: 0x00003941 File Offset: 0x00001B41
		public void 处理封包(商店修理全部 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.商店修理全部();
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0001E050 File Offset: 0x0001C250
		public void 处理封包(商店特修单件 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.商店特修单件(P.物品容器, P.物品位置);
		}

		// Token: 0x06000389 RID: 905 RVA: 0x0001E0A4 File Offset: 0x0001C2A4
		public void 处理封包(随身修理单件 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.随身修理单件(P.物品容器, P.物品位置, P.物品编号);
		}

		// Token: 0x0600038A RID: 906 RVA: 0x0000397E File Offset: 0x00001B7E
		public void 处理封包(随身特修全部 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.随身修理全部();
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0001E100 File Offset: 0x0001C300
		public void 处理封包(CharacterOrganizerBackpackPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家整理背包(P.背包类型);
		}

		// Token: 0x0600038C RID: 908 RVA: 0x0001E150 File Offset: 0x0001C350
		public void 处理封包(CharacterSplitItemsPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家拆分物品(P.当前背包, P.物品位置, P.拆分数量, P.目标背包, P.目标位置);
		}

		// Token: 0x0600038D RID: 909 RVA: 0x0001E1B8 File Offset: 0x0001C3B8
		public void 处理封包(CharacterBreakdownItemsPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
            if (Enum.TryParse<ItemBackPack>(P.背包类型.ToString(), out ItemBackPack ItemBackPack) && Enum.IsDefined(typeof(ItemBackPack), ItemBackPack))
            {
                this.绑定角色.玩家分解物品(P.背包类型, P.物品位置, P.分解数量);
                return;
            }
            this.尝试断开连接(new Exception("玩家分解物品时提供错误的枚举参数.即将断开连接."));
		}

		// Token: 0x0600038E RID: 910 RVA: 0x000039BB File Offset: 0x00001BBB
		public void 处理封包(CharacterSynthesisItemPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家合成物品();
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0001E250 File Offset: 0x0001C450
		public void 处理封包(玩家镶嵌灵石 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家镶嵌灵石(P.装备类型, P.装备位置, P.装备孔位, P.灵石类型, P.灵石位置);
		}

		// Token: 0x06000390 RID: 912 RVA: 0x0001E2B8 File Offset: 0x0001C4B8
		public void 处理封包(玩家拆除灵石 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家拆除灵石(P.装备类型, P.装备位置, P.装备孔位);
		}

		// Token: 0x06000391 RID: 913 RVA: 0x0001E314 File Offset: 0x0001C514
		public void 处理封包(OrdinaryInscriptionRefinementPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.OrdinaryInscriptionRefinementPacket(P.装备类型, P.装备位置, P.物品编号);
		}

		// Token: 0x06000392 RID: 914 RVA: 0x0001E370 File Offset: 0x0001C570
		public void 处理封包(高级铭文洗练 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.高级铭文洗练(P.装备类型, P.装备位置, P.物品编号);
		}

		// Token: 0x06000393 RID: 915 RVA: 0x0001E3CC File Offset: 0x0001C5CC
		public void 处理封包(ReplaceInscriptionRefinementPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.ReplaceInscriptionRefinementPacket(P.装备类型, P.装备位置, P.物品编号);
		}

		// Token: 0x06000394 RID: 916 RVA: 0x0001E428 File Offset: 0x0001C628
		public void 处理封包(ReplaceAdvancedInscriptionPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.高级洗练确认(P.装备类型, P.装备位置);
		}

		// Token: 0x06000395 RID: 917 RVA: 0x0001E47C File Offset: 0x0001C67C
		public void 处理封包(ReplaceLowLevelInscriptionsPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.替换洗练确认(P.装备类型, P.装备位置);
		}

		// Token: 0x06000396 RID: 918 RVA: 0x000039F8 File Offset: 0x00001BF8
		public void 处理封包(AbandonInscriptionReplacementPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.放弃替换铭文();
		}

		// Token: 0x06000397 RID: 919 RVA: 0x0001E4D0 File Offset: 0x0001C6D0
		public void 处理封包(UnlockDoubleInscriptionSlotPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.UnlockDoubleInscriptionSlotPacket(P.装备类型, P.装备位置, P.操作参数);
		}

		// Token: 0x06000398 RID: 920 RVA: 0x0001E52C File Offset: 0x0001C72C
		public void 处理封包(ToggleDoubleInscriptionBitPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.ToggleDoubleInscriptionBitPacket(P.装备类型, P.装备位置, P.操作参数);
		}

		// Token: 0x06000399 RID: 921 RVA: 0x0001E588 File Offset: 0x0001C788
		public void 处理封包(传承武器铭文 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.传承武器铭文(P.来源类型, P.来源位置, P.目标类型, P.目标位置);
		}

		// Token: 0x0600039A RID: 922 RVA: 0x0001E5E8 File Offset: 0x0001C7E8
		public void 处理封包(升级武器普通 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.升级武器普通(P.首饰组, P.材料组);
		}

		// Token: 0x0600039B RID: 923 RVA: 0x0001E63C File Offset: 0x0001C83C
		public void 处理封包(CharacterSelectionTargetPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家选中对象(P.对象编号);
		}

		// Token: 0x0600039C RID: 924 RVA: 0x0001E68C File Offset: 0x0001C88C
		public void 处理封包(开始Npcc对话 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.开始Npcc对话(P.对象编号);
		}

		// Token: 0x0600039D RID: 925 RVA: 0x0001E6DC File Offset: 0x0001C8DC
		public void 处理封包(继续Npcc对话 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.继续Npcc对话(P.对话编号);
		}

		// Token: 0x0600039E RID: 926 RVA: 0x0001E72C File Offset: 0x0001C92C
		public void 处理封包(查看玩家装备 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.查看对象装备(P.对象编号);
		}

		// Token: 0x0600039F RID: 927 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(RequestDragonguardDataPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(RequestSoulStoneDataPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(查询奖励找回 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x0001E77C File Offset: 0x0001C97C
		public void 处理封包(同步角色战力 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.查询玩家战力(P.对象编号);
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(查询问卷调查 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x0001E7CC File Offset: 0x0001C9CC
		public void 处理封包(玩家申请交易 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家申请交易(P.对象编号);
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x0001E81C File Offset: 0x0001CA1C
		public void 处理封包(玩家同意交易 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家同意交易(P.对象编号);
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00003A35 File Offset: 0x00001C35
		public void 处理封包(玩家结束交易 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家结束交易();
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x0001E86C File Offset: 0x0001CA6C
		public void 处理封包(玩家放入金币 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家放入金币(P.金币数量);
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x0001E8BC File Offset: 0x0001CABC
		public void 处理封包(玩家放入物品 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家放入物品(P.放入位置, P.放入物品, P.物品容器, P.物品位置);
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00003A72 File Offset: 0x00001C72
		public void 处理封包(玩家锁定交易 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家锁定交易();
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00003AAF File Offset: 0x00001CAF
		public void 处理封包(玩家解锁交易 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家解锁交易();
		}

		// Token: 0x060003AB RID: 939 RVA: 0x00003AEC File Offset: 0x00001CEC
		public void 处理封包(玩家确认交易 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家确认交易();
		}

		// Token: 0x060003AC RID: 940 RVA: 0x00003B29 File Offset: 0x00001D29
		public void 处理封包(玩家准备摆摊 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家准备摆摊();
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00003B66 File Offset: 0x00001D66
		public void 处理封包(玩家重整摊位 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家重整摊位();
		}

		// Token: 0x060003AE RID: 942 RVA: 0x00003BA3 File Offset: 0x00001DA3
		public void 处理封包(玩家开始摆摊 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家开始摆摊();
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00003BE0 File Offset: 0x00001DE0
		public void 处理封包(玩家收起摊位 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家收起摊位();
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0001E91C File Offset: 0x0001CB1C
		public void 处理封包(PutItemsInBoothPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.PutItemsInBoothPacket(P.放入位置, P.物品容器, P.物品位置, P.物品数量, P.物品价格);
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x0001E984 File Offset: 0x0001CB84
		public void 处理封包(取回摊位物品 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.取回摊位物品(P.取回位置);
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0001E9D4 File Offset: 0x0001CBD4
		public void 处理封包(更改摊位名字 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.更改摊位名字(P.摊位名字);
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0001EA24 File Offset: 0x0001CC24
		public void 处理封包(更改摊位外观 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.升级摊位外观(P.外观编号);
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0001EA74 File Offset: 0x0001CC74
		public void 处理封包(打开角色摊位 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家打开摊位(P.对象编号);
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0001EAC4 File Offset: 0x0001CCC4
		public void 处理封包(购买摊位物品 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.购买摊位物品(P.对象编号, P.物品位置, P.购买数量);
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0001EB20 File Offset: 0x0001CD20
		public void 处理封包(AddFriendsToFollowPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家添加关注(P.对象编号, P.对象名字);
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0001EB74 File Offset: 0x0001CD74
		public void 处理封包(取消好友关注 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家取消关注(P.对象编号);
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(CreateNewFriendGroupPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(MobileFriendsGroupPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0001EBC4 File Offset: 0x0001CDC4
		public void 处理封包(SendFriendChatPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			if (P.字节数据.Length < 7)
			{
				this.尝试断开连接(new Exception(string.Format("数据太短,断开连接.  处理封包: {0},  数据长度:{1}", P.GetType(), P.字节数据.Length)));
				return;
			}
			if (P.字节数据.Last<byte>() != 0)
			{
				this.尝试断开连接(new Exception(string.Format("数据错误,断开连接.  处理封包: {0},  无结束符.", P.GetType())));
				return;
			}
			this.绑定角色.玩家好友聊天(P.字节数据);
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0001EC70 File Offset: 0x0001CE70
		public void 处理封包(玩家添加仇人 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家添加仇人(P.对象编号);
		}

		// Token: 0x060003BC RID: 956 RVA: 0x0001ECC0 File Offset: 0x0001CEC0
		public void 处理封包(玩家删除仇人 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家删除仇人(P.对象编号);
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0001ED10 File Offset: 0x0001CF10
		public void 处理封包(玩家屏蔽对象 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家屏蔽目标(P.对象编号);
		}

		// Token: 0x060003BE RID: 958 RVA: 0x0001ED60 File Offset: 0x0001CF60
		public void 处理封包(玩家解除屏蔽 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家解除屏蔽(P.对象编号);
		}

		// Token: 0x060003BF RID: 959 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(玩家比较成就 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x0001EDB0 File Offset: 0x0001CFB0
		public void 处理封包(SendChatMessagePacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			if (P.字节数据.Length < 7)
			{
				this.尝试断开连接(new Exception(string.Format("数据太短,断开连接.  处理封包: {0},  数据长度:{1}", P.GetType(), P.字节数据.Length)));
				return;
			}
			if (P.字节数据.Last<byte>() != 0)
			{
				this.尝试断开连接(new Exception(string.Format("数据错误,断开连接.  处理封包: {0},  无结束符.", P.GetType())));
				return;
			}
			this.绑定角色.玩家发送广播(P.字节数据);
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x0001EE5C File Offset: 0x0001D05C
		public void 处理封包(SendSocialMessagePacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			if (P.字节数据.Length < 6)
			{
				this.尝试断开连接(new Exception(string.Format("数据太短,断开连接.  处理封包: {0},  数据长度:{1}", P.GetType(), P.字节数据.Length)));
				return;
			}
			if (P.字节数据.Last<byte>() != 0)
			{
				this.尝试断开连接(new Exception(string.Format("数据错误,断开连接.  处理封包: {0},  无结束符.", P.GetType())));
				return;
			}
			this.绑定角色.玩家发送消息(P.字节数据);
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x0001EF08 File Offset: 0x0001D108
		public void 处理封包(RequestCharacterDataPacket P)
		{
			if (this.当前阶段 != GameStage.场景加载 && this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.请求角色资料(P.角色编号);
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x00003C1D File Offset: 0x00001E1D
		public void 处理封包(上传社交信息 P)
		{
			if (this.当前阶段 != GameStage.场景加载 && this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x00003C57 File Offset: 0x00001E57
		public void 处理封包(查询附近队伍 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.查询附近队伍();
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x0001EF60 File Offset: 0x0001D160
		public void 处理封包(查询队伍信息 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.查询队伍信息(P.对象编号);
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x0001EFB0 File Offset: 0x0001D1B0
		public void 处理封包(申请创建队伍 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.申请创建队伍(P.对象编号, P.分配方式);
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x0001F004 File Offset: 0x0001D204
		public void 处理封包(SendTeamRequestPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.SendTeamRequestPacket(P.对象编号);
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x0001F054 File Offset: 0x0001D254
		public void 处理封包(申请离开队伍 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.申请队员离队(P.对象编号);
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0001F0A4 File Offset: 0x0001D2A4
		public void 处理封包(申请更改队伍 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.申请移交队长(P.队长编号);
		}

		// Token: 0x060003CA RID: 970 RVA: 0x0001F0F4 File Offset: 0x0001D2F4
		public void 处理封包(回应组队请求 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.回应组队请求(P.对象编号, P.组队方式, P.回应方式);
		}

		// Token: 0x060003CB RID: 971 RVA: 0x0001F150 File Offset: 0x0001D350
		public void 处理封包(玩家装配称号 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家使用称号(P.称号编号);
		}

		// Token: 0x060003CC RID: 972 RVA: 0x00003C94 File Offset: 0x00001E94
		public void 处理封包(玩家卸下称号 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家卸下称号();
		}

		// Token: 0x060003CD RID: 973 RVA: 0x0001F1A0 File Offset: 0x0001D3A0
		public void 处理封包(申请发送邮件 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.申请发送邮件(P.字节数据);
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00003CD1 File Offset: 0x00001ED1
		public void 处理封包(QueryMailboxContentPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.QueryMailboxContentPacket();
		}

		// Token: 0x060003CF RID: 975 RVA: 0x0001F1F0 File Offset: 0x0001D3F0
		public void 处理封包(查看邮件内容 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.查看邮件内容(P.邮件编号);
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x0001F240 File Offset: 0x0001D440
		public void 处理封包(删除指定邮件 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.删除指定邮件(P.邮件编号);
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x0001F290 File Offset: 0x0001D490
		public void 处理封包(提取邮件附件 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.提取邮件附件(P.邮件编号);
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x0001F2E0 File Offset: 0x0001D4E0
		public void 处理封包(查询行会名字 P)
		{
			if (this.当前阶段 != GameStage.场景加载 && this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.查询行会信息(P.行会编号);
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00003D0E File Offset: 0x00001F0E
		public void 处理封包(更多行会信息 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.更多行会信息();
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x0001F338 File Offset: 0x0001D538
		public void 处理封包(查看行会列表 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.查看行会列表(P.行会编号, P.查看方式);
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x0001F38C File Offset: 0x0001D58C
		public void 处理封包(FindCorrespondingGuildPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.FindCorrespondingGuildPacket(P.行会编号, P.行会名字);
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x0001F3E0 File Offset: 0x0001D5E0
		public void 处理封包(申请加入行会 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.申请加入行会(P.行会编号, P.行会名字);
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x00003D4B File Offset: 0x00001F4B
		public void 处理封包(查看申请列表 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.查看申请列表();
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x0001F434 File Offset: 0x0001D634
		public void 处理封包(处理入会申请 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.处理入会申请(P.对象编号, P.处理类型);
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0001F488 File Offset: 0x0001D688
		public void 处理封包(处理入会邀请 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.处理入会邀请(P.对象编号, P.处理类型);
		}

		// Token: 0x060003DA RID: 986 RVA: 0x0001F4DC File Offset: 0x0001D6DC
		public void 处理封包(InviteToJoinGuildPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.InviteToJoinGuildPacket(P.对象名字);
		}

		// Token: 0x060003DB RID: 987 RVA: 0x0001F52C File Offset: 0x0001D72C
		public void 处理封包(申请创建行会 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.申请创建行会(P.字节数据);
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00003D88 File Offset: 0x00001F88
		public void 处理封包(申请解散行会 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.申请解散行会();
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0001F57C File Offset: 0x0001D77C
		public void 处理封包(DonateGuildFundsPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.DonateGuildFundsPacket(P.金币数量);
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00003DC5 File Offset: 0x00001FC5
		public void 处理封包(DistributeGuildBenefitsPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.DistributeGuildBenefitsPacket();
		}

		// Token: 0x060003DF RID: 991 RVA: 0x00003E02 File Offset: 0x00002002
		public void 处理封包(申请离开行会 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.申请离开行会();
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x0001F5CC File Offset: 0x0001D7CC
		public void 处理封包(更改行会公告 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.更改行会公告(P.行会公告);
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x0001F61C File Offset: 0x0001D81C
		public void 处理封包(更改行会宣言 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.更改行会宣言(P.行会宣言);
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x0001F66C File Offset: 0x0001D86C
		public void 处理封包(设置行会禁言 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.设置行会禁言(P.对象编号, P.禁言状态);
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x0001F6C0 File Offset: 0x0001D8C0
		public void 处理封包(变更会员职位 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.变更会员职位(P.对象编号, P.对象职位);
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x0001F714 File Offset: 0x0001D914
		public void 处理封包(ExpelMembersPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.ExpelMembersPacket(P.对象编号);
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x0001F764 File Offset: 0x0001D964
		public void 处理封包(TransferPresidentPositionPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.TransferPresidentPositionPacket(P.对象编号);
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x0001F7B4 File Offset: 0x0001D9B4
		public void 处理封包(申请行会外交 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.申请行会外交(P.外交类型, P.外交时间, P.行会名字);
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x0001F810 File Offset: 0x0001DA10
		public void 处理封包(申请行会敌对 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.申请行会敌对(P.敌对时间, P.行会名字);
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x0001F864 File Offset: 0x0001DA64
		public void 处理封包(处理结盟申请 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.处理结盟申请(P.处理类型, P.行会编号);
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0001F8B8 File Offset: 0x0001DAB8
		public void 处理封包(申请解除结盟 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.申请解除结盟(P.行会编号);
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x0001F908 File Offset: 0x0001DB08
		public void 处理封包(申请解除敌对 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.申请解除敌对(P.行会编号);
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0001F958 File Offset: 0x0001DB58
		public void 处理封包(处理解敌申请 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.处理解除申请(P.行会编号, P.回应类型);
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(更改存储权限 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x00003E3F File Offset: 0x0000203F
		public void 处理封包(查看结盟申请 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.查看结盟申请();
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00003E7C File Offset: 0x0000207C
		public void 处理封包(更多GuildEvents P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.更多GuildEvents();
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00003C1D File Offset: 0x00001E1D
		public void 处理封包(QueryGuildAchievementsPacket P)
		{
			if (this.当前阶段 != GameStage.场景加载 && this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(开启行会活动 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(PublishWantedListPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00003C1D File Offset: 0x00001E1D
		public void 处理封包(SyncedWantedListPacket P)
		{
			if (this.当前阶段 != GameStage.场景加载 && this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00003C1D File Offset: 0x00001E1D
		public void 处理封包(StartGuildWarPacket P)
		{
			if (this.当前阶段 != GameStage.场景加载 && this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00003EB9 File Offset: 0x000020B9
		public void 处理封包(查询地图路线 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.查询地图路线();
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00003EF6 File Offset: 0x000020F6
		public void 处理封包(ToggleMapRoutePacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.ToggleMapRoutePacket();
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(跳过剧情动画 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0001F9AC File Offset: 0x0001DBAC
		public void 处理封包(更改收徒推送 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.更改收徒推送(P.收徒推送);
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x00003F33 File Offset: 0x00002133
		public void 处理封包(查询师门成员 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.查询师门成员();
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00003F70 File Offset: 0x00002170
		public void 处理封包(查询师门奖励 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.查询师门奖励();
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x00003FAD File Offset: 0x000021AD
		public void 处理封包(查询拜师名册 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.查询拜师名册();
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00003FEA File Offset: 0x000021EA
		public void 处理封包(查询收徒名册 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.查询收徒名册();
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(CongratsToApprenticeForUpgradePacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x0001F9FC File Offset: 0x0001DBFC
		public void 处理封包(玩家申请拜师 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家申请拜师(P.对象编号);
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x0001FA4C File Offset: 0x0001DC4C
		public void 处理封包(同意拜师申请 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.同意拜师申请(P.对象编号);
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x0001FA9C File Offset: 0x0001DC9C
		public void 处理封包(RefusedApplyApprenticeshipPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.RefusedApplyApprenticeshipPacket(P.对象编号);
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x0001FAEC File Offset: 0x0001DCEC
		public void 处理封包(玩家申请收徒 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.玩家申请收徒(P.对象编号);
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x0001FB3C File Offset: 0x0001DD3C
		public void 处理封包(同意收徒申请 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.同意收徒申请(P.对象编号);
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x0001FB8C File Offset: 0x0001DD8C
		public void 处理封包(RejectionApprenticeshipAppPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.RejectionApprenticeshipAppPacket(P.对象编号);
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x0001FBDC File Offset: 0x0001DDDC
		public void 处理封包(AppForExpulsionPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.AppForExpulsionPacket(P.对象编号);
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x00004027 File Offset: 0x00002227
		public void 处理封包(离开师门申请 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.离开师门申请();
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x00004064 File Offset: 0x00002264
		public void 处理封包(提交出师申请 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.提交出师申请();
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x0001FC2C File Offset: 0x0001DE2C
		public void 处理封包(查询排名榜单 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.查询排名榜单(P.榜单类型, P.起始位置);
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(查看演武排名 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(刷新演武挑战 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(开始战场演武 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(EnterMartialArtsBatllefieldPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(跨服武道排名 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x0001FC80 File Offset: 0x0001DE80
		public void 处理封包(LoginConsignmentPlatformPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.发送封包(new 社交错误提示
			{
				错误编号 = 12804
			});
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x0001FC80 File Offset: 0x0001DE80
		public void 处理封包(查询平台商品 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.发送封包(new 社交错误提示
			{
				错误编号 = 12804
			});
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x0001FC80 File Offset: 0x0001DE80
		public void 处理封包(InquireAboutSpecifiedProductPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.发送封包(new 社交错误提示
			{
				错误编号 = 12804
			});
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x0001FC80 File Offset: 0x0001DE80
		public void 处理封包(上架平台商品 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.发送封包(new 社交错误提示
			{
				错误编号 = 12804
			});
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x0001FCD4 File Offset: 0x0001DED4
		public void 处理封包(RequestTreasureDataPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.查询珍宝商店(P.数据版本);
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x000040A1 File Offset: 0x000022A1
		public void 处理封包(查询出售信息 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.查询出售信息();
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x0001FD24 File Offset: 0x0001DF24
		public void 处理封包(购买珍宝商品 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.购买珍宝商品(P.物品编号, P.购买数量);
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x0001FD78 File Offset: 0x0001DF78
		public void 处理封包(购买每周特惠 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.购买每周特惠(P.礼包编号);
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x0001FDC8 File Offset: 0x0001DFC8
		public void 处理封包(购买玛法特权 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.购买玛法特权(P.特权类型, P.购买数量);
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x0001FE1C File Offset: 0x0001E01C
		public void 处理封包(BookMarfaPrivilegesPacket P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.BookMarfaPrivilegesPacket(P.特权类型);
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x0001FE6C File Offset: 0x0001E06C
		public void 处理封包(领取特权礼包 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定角色.领取特权礼包(P.特权类型, P.礼包位置);
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x0000381C File Offset: 0x00001A1C
		public void 处理封包(玩家每日签到 P)
		{
			if (this.当前阶段 != GameStage.正在游戏)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
			}
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x0001FEC0 File Offset: 0x0001E0C0
		public void 处理封包(客户账号登录 P)
		{
            if (this.当前阶段 != GameStage.正在登录)
            {
                this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
            }
            else if (SystemData.数据.网卡封禁.TryGetValue(P.物理地址, out DateTime t) && t > MainProcess.当前时间)
            {
                this.尝试断开连接(new Exception("网卡封禁, 限制登录"));
            }
            else if (!NetworkServiceGateway.门票DataSheet.TryGetValue(P.登录门票, out TicketInformation TicketInformation))
            {
                this.尝试断开连接(new Exception("登录的门票不存在."));
            }
            else if (MainProcess.当前时间 > TicketInformation.有效时间)
            {
                this.尝试断开连接(new Exception("登录门票已经过期."));
            }
            else
            {
                AccountData AccountData2;
                if (GameDataGateway.AccountData表.Keyword.TryGetValue(TicketInformation.登录账号, out GameData GameData))
                {
                    AccountData AccountData = GameData as AccountData;
                    if (AccountData != null)
                    {
                        AccountData2 = AccountData;
                        goto IL_EF;
                    }
                }
                AccountData2 = new AccountData(TicketInformation.登录账号);
            IL_EF:
                AccountData AccountData3 = AccountData2;
                if (AccountData3.网络连接 != null)
                {
                    AccountData3.网络连接.发送封包(new LoginErrorMessagePacket
                    {
                        错误代码 = 260U
                    });
                    AccountData3.网络连接.尝试断开连接(new Exception("账号重复登录, 被踢下线."));
                    this.尝试断开连接(new Exception("账号已经在线, 无法登录."));
                }
                else
                {
                    AccountData3.账号登录(this, P.物理地址);
                }
            }
            NetworkServiceGateway.门票DataSheet.Remove(P.登录门票);
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x000040DE File Offset: 0x000022DE
		public void 处理封包(客户创建角色 P)
		{
			if (this.当前阶段 != GameStage.选择角色)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定账号.创建角色(this, P);
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x0000411D File Offset: 0x0000231D
		public void 处理封包(客户删除角色 P)
		{
			if (this.当前阶段 != GameStage.选择角色)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定账号.删除角色(this, P);
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x0000415C File Offset: 0x0000235C
		public void 处理封包(彻底删除角色 P)
		{
			if (this.当前阶段 != GameStage.选择角色)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定账号.永久删除(this, P);
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x0000419B File Offset: 0x0000239B
		public void 处理封包(客户进入游戏 P)
		{
			if (this.当前阶段 != GameStage.选择角色)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定账号.进入游戏(this, P);
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x000041DA File Offset: 0x000023DA
		public void 处理封包(客户GetBackCharacterPacket P)
		{
			if (this.当前阶段 != GameStage.选择角色)
			{
				this.尝试断开连接(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.当前阶段)));
				return;
			}
			this.绑定账号.GetBackCharacter(this, P);
		}

		// Token: 0x040007B2 RID: 1970
		private DateTime 断开时间;

		// Token: 0x040007B3 RID: 1971
		private bool 正在发送;

		// Token: 0x040007B4 RID: 1972
		private byte[] 剩余数据;

		// Token: 0x040007B5 RID: 1973
		private readonly EventHandler<Exception> 断网事件;

		// Token: 0x040007B6 RID: 1974
		private ConcurrentQueue<GamePacket> 接收列表;

		// Token: 0x040007B7 RID: 1975
		private ConcurrentQueue<GamePacket> 发送列表;

		// Token: 0x040007B8 RID: 1976
		public bool 正在断开;

		// Token: 0x040007B9 RID: 1977
		public readonly DateTime 接入时间;

		// Token: 0x040007BA RID: 1978
		public readonly TcpClient 当前连接;

		// Token: 0x040007BB RID: 1979
		public GameStage 当前阶段;

		// Token: 0x040007BC RID: 1980
		public AccountData 绑定账号;

		// Token: 0x040007BD RID: 1981
		public PlayerObject 绑定角色;

		// Token: 0x040007BE RID: 1982
		public string 网络地址;

		// Token: 0x040007BF RID: 1983
		public string 物理地址;

		// Token: 0x040007C0 RID: 1984
		public int 发送总数;

		// Token: 0x040007C1 RID: 1985
		public int 接收总数;
	}
}
