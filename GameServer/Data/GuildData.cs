using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GameServer.Maps;
using GameServer.Networking;

namespace GameServer.Data
{
	// Token: 0x0200026A RID: 618
	[FastDataReturnAttribute(检索字段 = "行会名字")]
	public sealed class GuildData : GameData
	{
		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060005A8 RID: 1448 RVA: 0x000054C0 File Offset: 0x000036C0
		public int 行会编号
		{
			get
			{
				return this.数据索引.V;
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060005A9 RID: 1449 RVA: 0x000054CD File Offset: 0x000036CD
		public int 创建时间
		{
			get
			{
				return ComputingClass.时间转换(this.创建日期.V);
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060005AA RID: 1450 RVA: 0x000054DF File Offset: 0x000036DF
		public string 会长名字
		{
			get
			{
				return this.行会会长.V.角色名字.V;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060005AB RID: 1451 RVA: 0x000054F6 File Offset: 0x000036F6
		// (set) Token: 0x060005AC RID: 1452 RVA: 0x00005503 File Offset: 0x00003703
		public CharacterData 会长数据
		{
			get
			{
				return this.行会会长.V;
			}
			set
			{
				if (this.行会会长.V != value)
				{
					this.行会会长.V = value;
				}
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060005AD RID: 1453 RVA: 0x0000551F File Offset: 0x0000371F
		// (set) Token: 0x060005AE RID: 1454 RVA: 0x00005527 File Offset: 0x00003727
		public DateTime 清理时间 { get; set; }

		// Token: 0x060005AF RID: 1455 RVA: 0x00005530 File Offset: 0x00003730
		public override string ToString()
		{
			DataMonitor<string> DataMonitor = this.行会名字;
			if (DataMonitor == null)
			{
				return null;
			}
			return DataMonitor.V;
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x00005543 File Offset: 0x00003743
		public GuildData()
		{
			
			this.申请列表 = new Dictionary<CharacterData, DateTime>();
			this.邀请列表 = new Dictionary<CharacterData, DateTime>();
			this.结盟申请 = new Dictionary<GuildData, DiplomaticApp>();
			this.解除申请 = new Dictionary<GuildData, DateTime>();
			
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x0002A588 File Offset: 0x00028788
		public GuildData(PlayerObject 创建玩家, string 行会名字, string 行会宣言)
		{
			
			this.申请列表 = new Dictionary<CharacterData, DateTime>();
			this.邀请列表 = new Dictionary<CharacterData, DateTime>();
			this.结盟申请 = new Dictionary<GuildData, DiplomaticApp>();
			this.解除申请 = new Dictionary<GuildData, DateTime>();
			
			this.行会名字.V = 行会名字;
			this.行会宣言.V = 行会宣言;
			this.行会公告.V = "祝大家游戏愉快.";
			this.行会会长.V = 创建玩家.CharacterData;
			this.创建人名.V = 创建玩家.对象名字;
			this.行会成员.Add(创建玩家.CharacterData, GuildJobs.会长);
			this.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.创建公会,
				第一参数 = 创建玩家.地图编号,
				事记时间 = ComputingClass.时间转换(MainProcess.当前时间)
			});
			this.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.加入公会,
				第一参数 = 创建玩家.地图编号,
				事记时间 = ComputingClass.时间转换(MainProcess.当前时间)
			});
			this.行会等级.V = 1;
			this.行会资金.V = 1000000;
			this.粮食数量.V = 1000000;
			this.木材数量.V = 1000000;
			this.石材数量.V = 1000000;
			this.铁矿数量.V = 1000000;
			this.创建日期.V = MainProcess.当前时间;
			GameDataGateway.GuildData表.AddData(this, true);
			SystemData.数据.更新行会(this);
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x0002A708 File Offset: 0x00028908
		public void 清理数据()
		{
			if (MainProcess.当前时间 > this.清理时间)
			{
				foreach (KeyValuePair<GuildData, DateTime> keyValuePair in this.结盟行会.ToList<KeyValuePair<GuildData, DateTime>>())
				{
					if (MainProcess.当前时间 > keyValuePair.Value)
					{
						this.结盟行会.Remove(keyValuePair.Key);
						keyValuePair.Key.结盟行会.Remove(this);
						this.发送封包(new 删除外交公告
						{
							外交类型 = 1,
							行会编号 = keyValuePair.Key.行会编号
						});
						keyValuePair.Key.发送封包(new 删除外交公告
						{
							外交类型 = 1,
							行会编号 = this.行会编号
						});
						NetworkServiceGateway.发送公告(string.Format("[{0}]和[{1}]的行会盟约已经到期自动解除", this, keyValuePair.Key), false);
					}
				}
				foreach (KeyValuePair<GuildData, DateTime> keyValuePair2 in this.敌对行会.ToList<KeyValuePair<GuildData, DateTime>>())
				{
					if (MainProcess.当前时间 > keyValuePair2.Value)
					{
						this.敌对行会.Remove(keyValuePair2.Key);
						keyValuePair2.Key.敌对行会.Remove(this);
						this.发送封包(new 删除外交公告
						{
							外交类型 = 2,
							行会编号 = keyValuePair2.Key.行会编号
						});
						keyValuePair2.Key.发送封包(new 删除外交公告
						{
							外交类型 = 2,
							行会编号 = this.行会编号
						});
						NetworkServiceGateway.发送公告(string.Format("[{0}]和[{1}]的行会敌对已经到期自动解除", this, keyValuePair2.Key), false);
					}
				}
				foreach (KeyValuePair<CharacterData, DateTime> keyValuePair3 in this.申请列表.ToList<KeyValuePair<CharacterData, DateTime>>())
				{
					if (MainProcess.当前时间 > keyValuePair3.Value)
					{
						this.申请列表.Remove(keyValuePair3.Key);
					}
				}
				foreach (KeyValuePair<CharacterData, DateTime> keyValuePair4 in this.邀请列表.ToList<KeyValuePair<CharacterData, DateTime>>())
				{
					if (MainProcess.当前时间 > keyValuePair4.Value)
					{
						this.邀请列表.Remove(keyValuePair4.Key);
					}
				}
				foreach (KeyValuePair<GuildData, DateTime> keyValuePair5 in this.解除申请.ToList<KeyValuePair<GuildData, DateTime>>())
				{
					if (MainProcess.当前时间 > keyValuePair5.Value)
					{
						this.解除申请.Remove(keyValuePair5.Key);
					}
				}
				foreach (KeyValuePair<GuildData, DiplomaticApp> keyValuePair6 in this.结盟申请.ToList<KeyValuePair<GuildData, DiplomaticApp>>())
				{
					if (MainProcess.当前时间 > keyValuePair6.Value.申请时间)
					{
						this.结盟申请.Remove(keyValuePair6.Key);
					}
				}
				this.清理时间 = MainProcess.当前时间.AddSeconds(1.0);
			}
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x0002AAB4 File Offset: 0x00028CB4
		public void 解散行会()
		{
			foreach (KeyValuePair<DateTime, GuildData> keyValuePair in SystemData.数据.申请行会.ToList<KeyValuePair<DateTime, GuildData>>())
			{
				if (keyValuePair.Value == this)
				{
					SystemData.数据.申请行会.Remove(keyValuePair.Key);
				}
			}
			this.发送封包(new 脱离行会应答
			{
				脱离方式 = 2
			});
			foreach (CharacterData CharacterData in this.行会成员.Keys)
			{
				CharacterData.当前行会 = null;
				客户网络 网络连接 = CharacterData.网络连接;
				if (网络连接 != null)
				{
					网络连接.发送封包(new 同步对象行会
					{
						对象编号 = CharacterData.角色编号
					});
				}
			}
			if (this.行会排名.V > 0)
			{
				SystemData.数据.行会人数排名.RemoveAt(this.行会排名.V - 1);
				for (int i = this.行会排名.V - 1; i < SystemData.数据.行会人数排名.Count; i++)
				{
					SystemData.数据.行会人数排名[i].行会排名.V = i + 1;
				}
			}
			this.行会成员.Clear();
			this.行会禁言.Clear();
			this.删除数据();
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x0002AC2C File Offset: 0x00028E2C
		public void 发送封包(GamePacket 封包)
		{
			foreach (CharacterData CharacterData in this.行会成员.Keys)
			{
				客户网络 网络连接 = CharacterData.网络连接;
				if (网络连接 != null)
				{
					网络连接.发送封包(封包);
				}
			}
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x0002AC88 File Offset: 0x00028E88
		public void 添加成员(CharacterData 成员, GuildJobs 职位 = GuildJobs.会员)
		{
			this.行会成员.Add(成员, 职位);
			成员.当前行会 = this;
			this.发送封包(new GuildJoinMemberPacket
			{
				对象编号 = 成员.角色编号,
				对象名字 = 成员.角色名字.V,
				对象职位 = 7,
				对象等级 = 成员.角色等级,
				对象职业 = (byte)成员.角色职业.V,
				当前地图 = (byte)成员.当前地图.V
			});
			if (成员.网络连接 == null)
			{
				this.发送封包(new SyncMemberInfoPacket
				{
					对象编号 = 成员.角色编号,
					对象信息 = ComputingClass.时间转换(成员.离线日期.V)
				});
			}
			客户网络 网络连接 = 成员.网络连接;
			if (网络连接 != null)
			{
				网络连接.发送封包(new GuildInfoAnnouncementPacket
				{
					字节数据 = this.行会信息描述()
				});
			}
			this.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.加入公会,
				第一参数 = 成员.角色编号,
				事记时间 = ComputingClass.时间转换(MainProcess.当前时间)
			});
			PlayerObject PlayerObject;
			if (MapGatewayProcess.玩家对象表.TryGetValue(成员.角色编号, out PlayerObject))
			{
				PlayerObject.发送封包(new 同步对象行会
				{
					对象编号 = 成员.角色编号,
					行会编号 = this.行会编号
				});
			}
			SystemData.数据.更新行会(this);
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x0002ADD0 File Offset: 0x00028FD0
		public void 退出行会(CharacterData 成员)
		{
			this.行会成员.Remove(成员);
			this.行会禁言.Remove(成员);
			成员.当前行会 = null;
			客户网络 网络连接 = 成员.网络连接;
			if (网络连接 != null)
			{
				网络连接.发送封包(new 脱离行会应答
				{
					脱离方式 = 1
				});
			}
			this.发送封包(new 脱离行会公告
			{
				对象编号 = 成员.角色编号
			});
			this.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.离开公会,
				第一参数 = 成员.角色编号,
				事记时间 = ComputingClass.时间转换(MainProcess.当前时间)
			});
			PlayerObject PlayerObject;
			if (MapGatewayProcess.玩家对象表.TryGetValue(成员.角色编号, out PlayerObject))
			{
				PlayerObject.发送封包(new 同步对象行会
				{
					对象编号 = 成员.角色编号
				});
			}
			SystemData.数据.更新行会(this);
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x0002AE98 File Offset: 0x00029098
		public void 逐出成员(CharacterData 主事, CharacterData 成员)
		{
			if (this.行会成员.Remove(成员))
			{
				this.行会禁言.Remove(成员);
				成员.当前行会 = null;
				客户网络 网络连接 = 成员.网络连接;
				if (网络连接 != null)
				{
					网络连接.发送封包(new 脱离行会应答
					{
						脱离方式 = 2
					});
				}
				this.发送封包(new 脱离行会公告
				{
					对象编号 = 成员.角色编号
				});
				this.添加事记(new GuildEvents
				{
					MemorandumType = MemorandumType.逐出公会,
					第一参数 = 成员.角色编号,
					第二参数 = 主事.角色编号,
					事记时间 = ComputingClass.时间转换(MainProcess.当前时间)
				});
				PlayerObject PlayerObject;
				if (MapGatewayProcess.玩家对象表.TryGetValue(成员.角色编号, out PlayerObject))
				{
					PlayerObject.发送封包(new 同步对象行会
					{
						对象编号 = 成员.角色编号
					});
				}
				SystemData.数据.更新行会(this);
			}
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x0002AF70 File Offset: 0x00029170
		public void 更改职位(CharacterData 主事, CharacterData 成员, GuildJobs 职位)
		{
			this.行会成员[成员] = 职位;
			this.行会成员[成员] = 职位;
			this.发送封包(new 变更职位公告
			{
				对象编号 = 成员.角色编号,
				对象职位 = (byte)职位
			});
			this.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.变更职位,
				第一参数 = 主事.角色编号,
				第二参数 = 成员.角色编号,
				第三参数 = (int)((byte)职位),
				第四参数 = (int)((byte)职位),
				事记时间 = ComputingClass.时间转换(MainProcess.当前时间)
			});
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x0000557C File Offset: 0x0000377C
		public void 更改宣言(CharacterData 主事, string 宣言)
		{
			this.行会宣言.V = 宣言;
			客户网络 网络连接 = 主事.网络连接;
			if (网络连接 == null)
			{
				return;
			}
			网络连接.发送封包(new 社交错误提示
			{
				错误编号 = 6747
			});
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x000055AA File Offset: 0x000037AA
		public void 更改公告(string 公告)
		{
			this.行会公告.V = 公告;
			this.发送封包(new 变更行会公告
			{
				字节数据 = Encoding.UTF8.GetBytes(公告 + "\0")
			});
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x0002B004 File Offset: 0x00029204
		public void 转移会长(CharacterData 会长, CharacterData 成员)
		{
			this.行会会长.V = 成员;
			this.行会成员[会长] = GuildJobs.会员;
			this.行会成员[成员] = GuildJobs.会长;
			this.发送封包(new 会长传位公告
			{
				当前编号 = 会长.角色编号,
				传位编号 = 成员.角色编号
			});
			this.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.会长传位,
				第一参数 = 会长.角色编号,
				第二参数 = 成员.角色编号,
				事记时间 = ComputingClass.时间转换(MainProcess.当前时间)
			});
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x0002B094 File Offset: 0x00029294
		public void 成员禁言(CharacterData 主事, CharacterData 成员, byte 禁言状态)
		{
			if (禁言状态 == 2 && this.行会禁言.Remove(成员))
			{
				this.发送封包(new GuildBanAnnouncementPacket
				{
					对象编号 = 成员.角色编号,
					禁言状态 = 2
				});
				return;
			}
			if (禁言状态 == 1)
			{
				this.行会禁言[成员] = MainProcess.当前时间;
				this.发送封包(new GuildBanAnnouncementPacket
				{
					对象编号 = 成员.角色编号,
					禁言状态 = 1
				});
				return;
			}
			客户网络 网络连接 = 主事.网络连接;
			if (网络连接 == null)
			{
				return;
			}
			网络连接.发送封包(new 社交错误提示
			{
				错误编号 = 6680
			});
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x0002B128 File Offset: 0x00029328
		public void 申请结盟(CharacterData 主事, GuildData 行会, byte 时间参数)
		{
			主事.网络连接.发送封包(new 申请结盟应答
			{
				行会编号 = 行会.行会编号
			});
			if (!行会.结盟申请.ContainsKey(this))
			{
				行会.行会提醒(GuildJobs.副长, 2);
			}
			行会.结盟申请[this] = new DiplomaticApp
			{
				外交时间 = 时间参数,
				申请时间 = MainProcess.当前时间.AddHours(10.0)
			};
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x0002B198 File Offset: 0x00029398
		public void 行会敌对(GuildData 行会, byte 时间参数)
		{
			this.敌对行会[行会] = (行会.敌对行会[this] = MainProcess.当前时间.AddDays((double)((时间参数 == 1) ? 1 : ((时间参数 == 2) ? 3 : 7))));
			this.发送封包(new AddDiplomaticAnnouncementPacket
			{
				外交类型 = 2,
				行会编号 = 行会.行会编号,
				行会名字 = 行会.行会名字.V,
				行会等级 = 行会.行会等级.V,
				行会人数 = (byte)行会.行会成员.Count,
				外交时间 = (int)(this.敌对行会[行会] - MainProcess.当前时间).TotalSeconds
			});
			行会.发送封包(new AddDiplomaticAnnouncementPacket
			{
				外交类型 = 2,
				行会编号 = this.行会编号,
				行会名字 = this.行会名字.V,
				行会等级 = this.行会等级.V,
				行会人数 = (byte)this.行会成员.Count,
				外交时间 = (int)(行会.敌对行会[this] - MainProcess.当前时间).TotalSeconds
			});
			this.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.行会敌对,
				第一参数 = this.行会编号,
				第二参数 = 行会.行会编号,
				事记时间 = ComputingClass.时间转换(MainProcess.当前时间)
			});
			行会.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.行会敌对,
				第一参数 = 行会.行会编号,
				第二参数 = this.行会编号,
				事记时间 = ComputingClass.时间转换(MainProcess.当前时间)
			});
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x0002B340 File Offset: 0x00029540
		public void 行会结盟(GuildData 行会)
		{
			this.结盟行会[行会] = (行会.结盟行会[this] = MainProcess.当前时间.AddDays((double)((this.结盟申请[行会].外交时间 == 1) ? 1 : ((this.结盟申请[行会].外交时间 == 2) ? 3 : 7))));
			this.发送封包(new AddDiplomaticAnnouncementPacket
			{
				外交类型 = 1,
				行会名字 = 行会.行会名字.V,
				行会编号 = 行会.行会编号,
				行会等级 = 行会.行会等级.V,
				行会人数 = (byte)行会.行会成员.Count,
				外交时间 = (int)(this.结盟行会[行会] - MainProcess.当前时间).TotalSeconds
			});
			行会.发送封包(new AddDiplomaticAnnouncementPacket
			{
				外交类型 = 1,
				行会名字 = this.行会名字.V,
				行会编号 = this.行会编号,
				行会等级 = this.行会等级.V,
				行会人数 = (byte)this.行会成员.Count,
				外交时间 = (int)(行会.结盟行会[this] - MainProcess.当前时间).TotalSeconds
			});
			this.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.行会结盟,
				第一参数 = this.行会编号,
				第二参数 = 行会.行会编号,
				事记时间 = ComputingClass.时间转换(MainProcess.当前时间)
			});
			行会.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.行会结盟,
				第一参数 = 行会.行会编号,
				第二参数 = this.行会编号,
				事记时间 = ComputingClass.时间转换(MainProcess.当前时间)
			});
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x0002B508 File Offset: 0x00029708
		public void 解除结盟(CharacterData 主事, GuildData 行会)
		{
			this.结盟行会.Remove(行会);
			行会.结盟行会.Remove(this);
			this.发送封包(new 删除外交公告
			{
				外交类型 = 1,
				行会编号 = 行会.行会编号
			});
			行会.发送封包(new 删除外交公告
			{
				外交类型 = 1,
				行会编号 = this.行会编号
			});
			this.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.取消结盟,
				第一参数 = this.行会编号,
				第二参数 = 行会.行会编号,
				事记时间 = ComputingClass.时间转换(MainProcess.当前时间)
			});
			行会.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.取消结盟,
				第一参数 = 行会.行会编号,
				第二参数 = this.行会编号,
				事记时间 = ComputingClass.时间转换(MainProcess.当前时间)
			});
			客户网络 网络连接 = 主事.网络连接;
			if (网络连接 == null)
			{
				return;
			}
			网络连接.发送封包(new 社交错误提示
			{
				错误编号 = 6812
			});
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x0002B604 File Offset: 0x00029804
		public void 申请解敌(CharacterData 主事, GuildData 敌对行会)
		{
			主事.网络连接.发送封包(new 社交错误提示
			{
				错误编号 = 6829
			});
			foreach (KeyValuePair<CharacterData, GuildJobs> keyValuePair in 敌对行会.行会成员)
			{
				if (keyValuePair.Value <= GuildJobs.副长)
				{
					客户网络 网络连接 = keyValuePair.Key.网络连接;
					if (网络连接 != null)
					{
						网络连接.发送封包(new DisarmHostileListPacket
						{
							申请类型 = 1,
							行会编号 = this.行会编号
						});
					}
				}
			}
			敌对行会.解除申请[this] = MainProcess.当前时间.AddHours(10.0);
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x0002B6C0 File Offset: 0x000298C0
		public void 解除敌对(GuildData 行会)
		{
			this.敌对行会.Remove(行会);
			行会.敌对行会.Remove(this);
			this.发送封包(new DisarmHostileListPacket
			{
				申请类型 = 2,
				行会编号 = 行会.行会编号
			});
			this.发送封包(new 删除外交公告
			{
				外交类型 = 2,
				行会编号 = 行会.行会编号
			});
			行会.发送封包(new 删除外交公告
			{
				外交类型 = 2,
				行会编号 = this.行会编号
			});
			this.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.取消敌对,
				第一参数 = this.行会编号,
				第二参数 = 行会.行会编号,
				事记时间 = ComputingClass.时间转换(MainProcess.当前时间)
			});
			行会.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.取消敌对,
				第一参数 = 行会.行会编号,
				第二参数 = this.行会编号,
				事记时间 = ComputingClass.时间转换(MainProcess.当前时间)
			});
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x0002B7B8 File Offset: 0x000299B8
		public void 发送邮件(GuildJobs 职位, string 标题, string 内容)
		{
			foreach (KeyValuePair<CharacterData, GuildJobs> keyValuePair in this.行会成员)
			{
				if (keyValuePair.Value <= 职位)
				{
					keyValuePair.Key.发送邮件(new MailData(null, 标题, 内容, null));
				}
			}
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x0002B820 File Offset: 0x00029A20
		public void 添加事记(GuildEvents 事记)
		{
			this.GuildEvents.Insert(0, 事记);
			this.发送封包(new AddGuildMemoPacket
			{
				MemorandumType = (byte)事记.MemorandumType,
				第一参数 = 事记.第一参数,
				第二参数 = 事记.第二参数,
				第三参数 = 事记.第三参数,
				第四参数 = 事记.第四参数,
				事记时间 = 事记.事记时间
			});
			while (this.GuildEvents.Count > 10)
			{
				this.GuildEvents.RemoveAt(this.GuildEvents.Count - 1);
			}
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x0002B8B8 File Offset: 0x00029AB8
		public void 行会提醒(GuildJobs 职位, byte 提醒类型)
		{
			foreach (KeyValuePair<CharacterData, GuildJobs> keyValuePair in this.行会成员)
			{
				客户网络 客户网络;
				if (keyValuePair.Value <= 职位 && keyValuePair.Key.角色在线(out 客户网络))
				{
					客户网络.发送封包(new SendGuildNoticePacket
					{
						提醒类型 = 提醒类型
					});
				}
			}
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x0002B92C File Offset: 0x00029B2C
		public byte[] 行会检索描述()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream(new byte[229]))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(this.行会编号);
					byte[] array = new byte[25];
					Encoding.UTF8.GetBytes(this.行会名字.V).CopyTo(array, 0);
					binaryWriter.Write(array);
					binaryWriter.Write(this.行会等级.V);
					binaryWriter.Write((byte)this.行会成员.Count);
					binaryWriter.Write(0);
					array = new byte[32];
					Encoding.UTF8.GetBytes(this.会长名字).CopyTo(array, 0);
					binaryWriter.Write(array);
					array = new byte[32];
					Encoding.UTF8.GetBytes(this.创建人名.V).CopyTo(array, 0);
					binaryWriter.Write(array);
					binaryWriter.Write(this.创建时间);
					array = new byte[101];
					Encoding.UTF8.GetBytes(this.行会宣言.V).CopyTo(array, 0);
					binaryWriter.Write(array);
					binaryWriter.Write(new byte[17]);
					binaryWriter.Write(new byte[8]);
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x0002BAA4 File Offset: 0x00029CA4
		public byte[] 行会信息描述()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(this.行会编号);
					binaryWriter.Write(Encoding.UTF8.GetBytes(this.行会名字.V));
					binaryWriter.Seek(29, SeekOrigin.Begin);
					binaryWriter.Write(this.行会等级.V);
					binaryWriter.Write((byte)this.行会成员.Count);
					binaryWriter.Write(this.行会资金.V);
					binaryWriter.Write(this.创建时间);
					binaryWriter.Seek(43, SeekOrigin.Begin);
					binaryWriter.Write(Encoding.UTF8.GetBytes(this.会长名字));
					binaryWriter.Seek(75, SeekOrigin.Begin);
					binaryWriter.Write(Encoding.UTF8.GetBytes(this.创建人名.V));
					binaryWriter.Seek(107, SeekOrigin.Begin);
					binaryWriter.Write(Encoding.UTF8.GetBytes(this.行会公告.V));
					binaryWriter.Seek(4258, SeekOrigin.Begin);
					binaryWriter.Write(this.粮食数量.V);
					binaryWriter.Write(this.木材数量.V);
					binaryWriter.Write(this.石材数量.V);
					binaryWriter.Write(this.铁矿数量.V);
					binaryWriter.Write(402);
					binaryWriter.Seek(7960, SeekOrigin.Begin);
					foreach (KeyValuePair<CharacterData, GuildJobs> keyValuePair in this.行会成员)
					{
						binaryWriter.Write(keyValuePair.Key.角色编号);
						byte[] array = new byte[32];
						Encoding.UTF8.GetBytes(keyValuePair.Key.角色名字.V).CopyTo(array, 0);
						binaryWriter.Write(array);
						binaryWriter.Write((byte)keyValuePair.Value);
						binaryWriter.Write(keyValuePair.Key.角色等级);
						binaryWriter.Write((byte)keyValuePair.Key.角色职业.V);
						binaryWriter.Write(keyValuePair.Key.当前地图.V);
						客户网络 客户网络;
						binaryWriter.Write(keyValuePair.Key.角色在线(out 客户网络) ? 0 : ComputingClass.时间转换(keyValuePair.Key.离线日期.V));
						binaryWriter.Write(0);
						binaryWriter.Write(this.行会禁言.ContainsKey(keyValuePair.Key));
					}
					binaryWriter.Seek(330, SeekOrigin.Begin);
					binaryWriter.Write((byte)Math.Min(10, this.GuildEvents.Count));
					int num = 0;
					while (num < 10 && num < this.GuildEvents.Count)
					{
						binaryWriter.Write((byte)this.GuildEvents[num].MemorandumType);
						binaryWriter.Write(this.GuildEvents[num].第一参数);
						binaryWriter.Write(this.GuildEvents[num].第二参数);
						binaryWriter.Write(this.GuildEvents[num].第三参数);
						binaryWriter.Write(this.GuildEvents[num].第四参数);
						binaryWriter.Write(this.GuildEvents[num].事记时间);
						num++;
					}
					binaryWriter.Seek(1592, SeekOrigin.Begin);
					binaryWriter.Write((byte)this.结盟行会.Count);
					foreach (KeyValuePair<GuildData, DateTime> keyValuePair2 in this.结盟行会)
					{
						binaryWriter.Write(1);
						binaryWriter.Write(keyValuePair2.Key.行会编号);
						binaryWriter.Write(ComputingClass.时间转换(keyValuePair2.Value));
						binaryWriter.Write(keyValuePair2.Key.行会等级.V);
						binaryWriter.Write((byte)keyValuePair2.Key.行会成员.Count);
						byte[] array2 = new byte[25];
						Encoding.UTF8.GetBytes(keyValuePair2.Key.行会名字.V).CopyTo(array2, 0);
						binaryWriter.Write(array2);
					}
					binaryWriter.Seek(1953, SeekOrigin.Begin);
					binaryWriter.Write((byte)this.敌对行会.Count);
					foreach (KeyValuePair<GuildData, DateTime> keyValuePair3 in this.敌对行会)
					{
						binaryWriter.Write(2);
						binaryWriter.Write(keyValuePair3.Key.行会编号);
						binaryWriter.Write(ComputingClass.时间转换(keyValuePair3.Value));
						binaryWriter.Write(keyValuePair3.Key.行会等级.V);
						binaryWriter.Write((byte)keyValuePair3.Key.行会成员.Count);
						byte[] array3 = new byte[25];
						Encoding.UTF8.GetBytes(keyValuePair3.Key.行会名字.V).CopyTo(array3, 0);
						binaryWriter.Write(array3);
					}
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x0002C058 File Offset: 0x0002A258
		public byte[] 入会申请描述()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write((ushort)this.申请列表.Count);
					foreach (CharacterData CharacterData in this.申请列表.Keys)
					{
						binaryWriter.Write(CharacterData.角色编号);
						byte[] array = new byte[32];
						Encoding.UTF8.GetBytes(CharacterData.角色名字.V).CopyTo(array, 0);
						binaryWriter.Write(array);
						binaryWriter.Write(CharacterData.角色等级);
						binaryWriter.Write(CharacterData.角色等级);
						客户网络 客户网络;
						binaryWriter.Write(CharacterData.角色在线(out 客户网络) ? ComputingClass.时间转换(MainProcess.当前时间) : ComputingClass.时间转换(CharacterData.离线日期.V));
					}
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x0002C188 File Offset: 0x0002A388
		public byte[] 结盟申请描述()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write((byte)this.结盟申请.Count);
					foreach (KeyValuePair<GuildData, DiplomaticApp> keyValuePair in this.结盟申请)
					{
						binaryWriter.Write(keyValuePair.Key.行会编号);
						byte[] array = new byte[25];
						Encoding.UTF8.GetBytes(keyValuePair.Key.行会名字.V).CopyTo(array, 0);
						binaryWriter.Write(array);
						binaryWriter.Write(keyValuePair.Key.行会等级.V);
						binaryWriter.Write((byte)keyValuePair.Key.行会成员.Count);
						array = new byte[32];
						Encoding.UTF8.GetBytes(keyValuePair.Key.会长名字).CopyTo(array, 0);
						binaryWriter.Write(array);
						binaryWriter.Write(ComputingClass.时间转换(keyValuePair.Value.申请时间));
					}
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x0002C314 File Offset: 0x0002A514
		public byte[] 解除申请描述()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream(new byte[256]))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					foreach (KeyValuePair<GuildData, DateTime> keyValuePair in this.解除申请)
					{
						binaryWriter.Write(keyValuePair.Key.行会编号);
					}
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x0002C3C4 File Offset: 0x0002A5C4
		public byte[] 更多事记描述()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write((ushort)Math.Max(0, this.GuildEvents.Count - 10));
					for (int i = 10; i < this.GuildEvents.Count; i++)
					{
						binaryWriter.Write((byte)this.GuildEvents[i].MemorandumType);
						binaryWriter.Write(this.GuildEvents[i].第一参数);
						binaryWriter.Write(this.GuildEvents[i].第二参数);
						binaryWriter.Write(this.GuildEvents[i].第三参数);
						binaryWriter.Write(this.GuildEvents[i].第四参数);
						binaryWriter.Write(this.GuildEvents[i].事记时间);
					}
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		// Token: 0x04000849 RID: 2121
		public readonly DataMonitor<CharacterData> 行会会长;

		// Token: 0x0400084A RID: 2122
		public readonly DataMonitor<DateTime> 创建日期;

		// Token: 0x0400084B RID: 2123
		public readonly DataMonitor<string> 行会名字;

		// Token: 0x0400084C RID: 2124
		public readonly DataMonitor<string> 创建人名;

		// Token: 0x0400084D RID: 2125
		public readonly DataMonitor<string> 行会宣言;

		// Token: 0x0400084E RID: 2126
		public readonly DataMonitor<string> 行会公告;

		// Token: 0x0400084F RID: 2127
		public readonly DataMonitor<byte> 行会等级;

		// Token: 0x04000850 RID: 2128
		public readonly DataMonitor<int> 行会资金;

		// Token: 0x04000851 RID: 2129
		public readonly DataMonitor<int> 粮食数量;

		// Token: 0x04000852 RID: 2130
		public readonly DataMonitor<int> 木材数量;

		// Token: 0x04000853 RID: 2131
		public readonly DataMonitor<int> 石材数量;

		// Token: 0x04000854 RID: 2132
		public readonly DataMonitor<int> 铁矿数量;

		// Token: 0x04000855 RID: 2133
		public readonly DataMonitor<int> 行会排名;

		// Token: 0x04000856 RID: 2134
		public readonly ListMonitor<GuildEvents> GuildEvents;

		// Token: 0x04000857 RID: 2135
		public readonly MonitorDictionary<CharacterData, GuildJobs> 行会成员;

		// Token: 0x04000858 RID: 2136
		public readonly MonitorDictionary<CharacterData, DateTime> 行会禁言;

		// Token: 0x04000859 RID: 2137
		public readonly MonitorDictionary<GuildData, DateTime> 结盟行会;

		// Token: 0x0400085A RID: 2138
		public readonly MonitorDictionary<GuildData, DateTime> 敌对行会;

		// Token: 0x0400085B RID: 2139
		public Dictionary<CharacterData, DateTime> 申请列表;

		// Token: 0x0400085C RID: 2140
		public Dictionary<CharacterData, DateTime> 邀请列表;

		// Token: 0x0400085D RID: 2141
		public Dictionary<GuildData, DiplomaticApp> 结盟申请;

		// Token: 0x0400085E RID: 2142
		public Dictionary<GuildData, DateTime> 解除申请;
	}
}
