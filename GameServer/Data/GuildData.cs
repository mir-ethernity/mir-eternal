using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GameServer.Maps;
using GameServer.Networking;

namespace GameServer.Data
{
	
	[FastDataReturnAttribute(检索字段 = "GuildName")]
	public sealed class GuildData : GameData
	{
		
		public int 行会编号
		{
			get
			{
				return this.数据索引.V;
			}
		}

		
		public int 创建时间
		{
			get
			{
				return ComputingClass.TimeShift(this.CreatedDate.V);
			}
		}

		
		public string 会长名字
		{
			get
			{
				return this.行会会长.V.CharName.V;
			}
		}

		
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

		
		public DateTime 清理时间 { get; set; }

		
		public override string ToString()
		{
			DataMonitor<string> DataMonitor = this.GuildName;
			if (DataMonitor == null)
			{
				return null;
			}
			return DataMonitor.V;
		}

		
		public GuildData()
		{
			
			this.申请列表 = new Dictionary<CharacterData, DateTime>();
			this.邀请列表 = new Dictionary<CharacterData, DateTime>();
			this.结盟申请 = new Dictionary<GuildData, DiplomaticApp>();
			this.解除申请 = new Dictionary<GuildData, DateTime>();
			
		}

		
		public GuildData(PlayerObject 创建玩家, string GuildName, string 行会宣言)
		{
			
			this.申请列表 = new Dictionary<CharacterData, DateTime>();
			this.邀请列表 = new Dictionary<CharacterData, DateTime>();
			this.结盟申请 = new Dictionary<GuildData, DiplomaticApp>();
			this.解除申请 = new Dictionary<GuildData, DateTime>();
			
			this.GuildName.V = GuildName;
			this.行会宣言.V = 行会宣言;
			this.行会公告.V = "Enjoy your game.";
			this.行会会长.V = 创建玩家.CharacterData;
			this.创建人名.V = 创建玩家.对象名字;
			this.行会成员.Add(创建玩家.CharacterData, GuildJobs.会长);
			this.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.创建公会,
				第一参数 = 创建玩家.ObjectId,
				事记时间 = ComputingClass.TimeShift(MainProcess.CurrentTime)
			});
			this.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.加入公会,
				第一参数 = 创建玩家.ObjectId,
				事记时间 = ComputingClass.TimeShift(MainProcess.CurrentTime)
			});
			this.行会等级.V = 1;
			this.行会资金.V = 1000000;
			this.粮食数量.V = 1000000;
			this.木材数量.V = 1000000;
			this.石材数量.V = 1000000;
			this.铁矿数量.V = 1000000;
			this.CreatedDate.V = MainProcess.CurrentTime;
			GameDataGateway.GuildData表.AddData(this, true);
			SystemData.Data.更新行会(this);
		}

		
		public void 清理数据()
		{
			if (MainProcess.CurrentTime > this.清理时间)
			{
				foreach (KeyValuePair<GuildData, DateTime> keyValuePair in this.结盟行会.ToList<KeyValuePair<GuildData, DateTime>>())
				{
					if (MainProcess.CurrentTime > keyValuePair.Value)
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
						NetworkServiceGateway.发送公告(string.Format("The guild covenant for [{0}] and [{1}] has expired and been automatically dissolved", this, keyValuePair.Key), false);
					}
				}
				foreach (KeyValuePair<GuildData, DateTime> keyValuePair2 in this.Hostility行会.ToList<KeyValuePair<GuildData, DateTime>>())
				{
					if (MainProcess.CurrentTime > keyValuePair2.Value)
					{
						this.Hostility行会.Remove(keyValuePair2.Key);
						keyValuePair2.Key.Hostility行会.Remove(this);
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
						NetworkServiceGateway.发送公告(string.Format("Guild hostilities for [{0}] and [{1}] have expired and are automatically lifted", this, keyValuePair2.Key), false);
					}
				}
				foreach (KeyValuePair<CharacterData, DateTime> keyValuePair3 in this.申请列表.ToList<KeyValuePair<CharacterData, DateTime>>())
				{
					if (MainProcess.CurrentTime > keyValuePair3.Value)
					{
						this.申请列表.Remove(keyValuePair3.Key);
					}
				}
				foreach (KeyValuePair<CharacterData, DateTime> keyValuePair4 in this.邀请列表.ToList<KeyValuePair<CharacterData, DateTime>>())
				{
					if (MainProcess.CurrentTime > keyValuePair4.Value)
					{
						this.邀请列表.Remove(keyValuePair4.Key);
					}
				}
				foreach (KeyValuePair<GuildData, DateTime> keyValuePair5 in this.解除申请.ToList<KeyValuePair<GuildData, DateTime>>())
				{
					if (MainProcess.CurrentTime > keyValuePair5.Value)
					{
						this.解除申请.Remove(keyValuePair5.Key);
					}
				}
				foreach (KeyValuePair<GuildData, DiplomaticApp> keyValuePair6 in this.结盟申请.ToList<KeyValuePair<GuildData, DiplomaticApp>>())
				{
					if (MainProcess.CurrentTime > keyValuePair6.Value.申请时间)
					{
						this.结盟申请.Remove(keyValuePair6.Key);
					}
				}
				this.清理时间 = MainProcess.CurrentTime.AddSeconds(1.0);
			}
		}

		
		public void 解散行会()
		{
			foreach (KeyValuePair<DateTime, GuildData> keyValuePair in SystemData.Data.申请行会.ToList<KeyValuePair<DateTime, GuildData>>())
			{
				if (keyValuePair.Value == this)
				{
					SystemData.Data.申请行会.Remove(keyValuePair.Key);
				}
			}
			this.发送封包(new 脱离行会应答
			{
				脱离方式 = 2
			});
			foreach (CharacterData CharacterData in this.行会成员.Keys)
			{
				CharacterData.当前行会 = null;
				SConnection 网络连接 = CharacterData.ActiveConnection;
				if (网络连接 != null)
				{
					网络连接.发送封包(new 同步对象行会
					{
						对象编号 = CharacterData.Id
					});
				}
			}
			if (this.行会排名.V > 0)
			{
				SystemData.Data.行会人数排名.RemoveAt(this.行会排名.V - 1);
				for (int i = this.行会排名.V - 1; i < SystemData.Data.行会人数排名.Count; i++)
				{
					SystemData.Data.行会人数排名[i].行会排名.V = i + 1;
				}
			}
			this.行会成员.Clear();
			this.行会禁言.Clear();
			this.Delete();
		}

		
		public void 发送封包(GamePacket 封包)
		{
			foreach (CharacterData CharacterData in this.行会成员.Keys)
			{
				SConnection 网络连接 = CharacterData.ActiveConnection;
				if (网络连接 != null)
				{
					网络连接.发送封包(封包);
				}
			}
		}

		
		public void 添加成员(CharacterData 成员, GuildJobs 职位 = GuildJobs.会员)
		{
			this.行会成员.Add(成员, 职位);
			成员.当前行会 = this;
			this.发送封包(new GuildJoinMemberPacket
			{
				对象编号 = 成员.Id,
				对象名字 = 成员.CharName.V,
				对象职位 = 7,
				对象等级 = 成员.角色等级,
				对象职业 = (byte)成员.CharRole.V,
				CurrentMap = (byte)成员.CurrentMap.V
			});
			if (成员.ActiveConnection == null)
			{
				this.发送封包(new SyncMemberInfoPacket
				{
					对象编号 = 成员.Id,
					对象信息 = ComputingClass.TimeShift(成员.OfflineDate.V)
				});
			}
			SConnection 网络连接 = 成员.ActiveConnection;
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
				第一参数 = 成员.Id,
				事记时间 = ComputingClass.TimeShift(MainProcess.CurrentTime)
			});
			PlayerObject PlayerObject;
			if (MapGatewayProcess.玩家对象表.TryGetValue(成员.Id, out PlayerObject))
			{
				PlayerObject.SendPacket(new 同步对象行会
				{
					对象编号 = 成员.Id,
					行会编号 = this.行会编号
				});
			}
			SystemData.Data.更新行会(this);
		}

		
		public void 退出行会(CharacterData 成员)
		{
			this.行会成员.Remove(成员);
			this.行会禁言.Remove(成员);
			成员.当前行会 = null;
			SConnection 网络连接 = 成员.ActiveConnection;
			if (网络连接 != null)
			{
				网络连接.发送封包(new 脱离行会应答
				{
					脱离方式 = 1
				});
			}
			this.发送封包(new 脱离行会公告
			{
				对象编号 = 成员.Id
			});
			this.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.离开公会,
				第一参数 = 成员.Id,
				事记时间 = ComputingClass.TimeShift(MainProcess.CurrentTime)
			});
			PlayerObject PlayerObject;
			if (MapGatewayProcess.玩家对象表.TryGetValue(成员.Id, out PlayerObject))
			{
				PlayerObject.SendPacket(new 同步对象行会
				{
					对象编号 = 成员.Id
				});
			}
			SystemData.Data.更新行会(this);
		}

		
		public void 逐出成员(CharacterData 主事, CharacterData 成员)
		{
			if (this.行会成员.Remove(成员))
			{
				this.行会禁言.Remove(成员);
				成员.当前行会 = null;
				SConnection 网络连接 = 成员.ActiveConnection;
				if (网络连接 != null)
				{
					网络连接.发送封包(new 脱离行会应答
					{
						脱离方式 = 2
					});
				}
				this.发送封包(new 脱离行会公告
				{
					对象编号 = 成员.Id
				});
				this.添加事记(new GuildEvents
				{
					MemorandumType = MemorandumType.逐出公会,
					第一参数 = 成员.Id,
					第二参数 = 主事.Id,
					事记时间 = ComputingClass.TimeShift(MainProcess.CurrentTime)
				});
				PlayerObject PlayerObject;
				if (MapGatewayProcess.玩家对象表.TryGetValue(成员.Id, out PlayerObject))
				{
					PlayerObject.SendPacket(new 同步对象行会
					{
						对象编号 = 成员.Id
					});
				}
				SystemData.Data.更新行会(this);
			}
		}

		
		public void 更改职位(CharacterData 主事, CharacterData 成员, GuildJobs 职位)
		{
			this.行会成员[成员] = 职位;
			this.行会成员[成员] = 职位;
			this.发送封包(new 变更职位公告
			{
				对象编号 = 成员.Id,
				对象职位 = (byte)职位
			});
			this.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.变更职位,
				第一参数 = 主事.Id,
				第二参数 = 成员.Id,
				第三参数 = (int)((byte)职位),
				第四参数 = (int)((byte)职位),
				事记时间 = ComputingClass.TimeShift(MainProcess.CurrentTime)
			});
		}

		
		public void 更改宣言(CharacterData 主事, string 宣言)
		{
			this.行会宣言.V = 宣言;
			SConnection 网络连接 = 主事.ActiveConnection;
			if (网络连接 == null)
			{
				return;
			}
			网络连接.发送封包(new 社交错误提示
			{
				错误编号 = 6747
			});
		}

		
		public void 更改公告(string 公告)
		{
			this.行会公告.V = 公告;
			this.发送封包(new 变更行会公告
			{
				字节数据 = Encoding.UTF8.GetBytes(公告 + "\0")
			});
		}

		
		public void 转移会长(CharacterData 会长, CharacterData 成员)
		{
			this.行会会长.V = 成员;
			this.行会成员[会长] = GuildJobs.会员;
			this.行会成员[成员] = GuildJobs.会长;
			this.发送封包(new 会长传位公告
			{
				当前编号 = 会长.Id,
				传位编号 = 成员.Id
			});
			this.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.会长传位,
				第一参数 = 会长.Id,
				第二参数 = 成员.Id,
				事记时间 = ComputingClass.TimeShift(MainProcess.CurrentTime)
			});
		}

		
		public void 成员禁言(CharacterData 主事, CharacterData 成员, byte 禁言状态)
		{
			if (禁言状态 == 2 && this.行会禁言.Remove(成员))
			{
				this.发送封包(new GuildBanAnnouncementPacket
				{
					对象编号 = 成员.Id,
					禁言状态 = 2
				});
				return;
			}
			if (禁言状态 == 1)
			{
				this.行会禁言[成员] = MainProcess.CurrentTime;
				this.发送封包(new GuildBanAnnouncementPacket
				{
					对象编号 = 成员.Id,
					禁言状态 = 1
				});
				return;
			}
			SConnection 网络连接 = 主事.ActiveConnection;
			if (网络连接 == null)
			{
				return;
			}
			网络连接.发送封包(new 社交错误提示
			{
				错误编号 = 6680
			});
		}

		
		public void 申请结盟(CharacterData 主事, GuildData 行会, byte 时间参数)
		{
			主事.ActiveConnection.发送封包(new 申请结盟应答
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
				申请时间 = MainProcess.CurrentTime.AddHours(10.0)
			};
		}

		
		public void 行会Hostility(GuildData 行会, byte 时间参数)
		{
			this.Hostility行会[行会] = (行会.Hostility行会[this] = MainProcess.CurrentTime.AddDays((double)((时间参数 == 1) ? 1 : ((时间参数 == 2) ? 3 : 7))));
			this.发送封包(new AddDiplomaticAnnouncementPacket
			{
				外交类型 = 2,
				行会编号 = 行会.行会编号,
				GuildName = 行会.GuildName.V,
				行会等级 = 行会.行会等级.V,
				行会人数 = (byte)行会.行会成员.Count,
				外交时间 = (int)(this.Hostility行会[行会] - MainProcess.CurrentTime).TotalSeconds
			});
			行会.发送封包(new AddDiplomaticAnnouncementPacket
			{
				外交类型 = 2,
				行会编号 = this.行会编号,
				GuildName = this.GuildName.V,
				行会等级 = this.行会等级.V,
				行会人数 = (byte)this.行会成员.Count,
				外交时间 = (int)(行会.Hostility行会[this] - MainProcess.CurrentTime).TotalSeconds
			});
			this.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.行会Hostility,
				第一参数 = this.行会编号,
				第二参数 = 行会.行会编号,
				事记时间 = ComputingClass.TimeShift(MainProcess.CurrentTime)
			});
			行会.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.行会Hostility,
				第一参数 = 行会.行会编号,
				第二参数 = this.行会编号,
				事记时间 = ComputingClass.TimeShift(MainProcess.CurrentTime)
			});
		}

		
		public void 行会结盟(GuildData 行会)
		{
			this.结盟行会[行会] = (行会.结盟行会[this] = MainProcess.CurrentTime.AddDays((double)((this.结盟申请[行会].外交时间 == 1) ? 1 : ((this.结盟申请[行会].外交时间 == 2) ? 3 : 7))));
			this.发送封包(new AddDiplomaticAnnouncementPacket
			{
				外交类型 = 1,
				GuildName = 行会.GuildName.V,
				行会编号 = 行会.行会编号,
				行会等级 = 行会.行会等级.V,
				行会人数 = (byte)行会.行会成员.Count,
				外交时间 = (int)(this.结盟行会[行会] - MainProcess.CurrentTime).TotalSeconds
			});
			行会.发送封包(new AddDiplomaticAnnouncementPacket
			{
				外交类型 = 1,
				GuildName = this.GuildName.V,
				行会编号 = this.行会编号,
				行会等级 = this.行会等级.V,
				行会人数 = (byte)this.行会成员.Count,
				外交时间 = (int)(行会.结盟行会[this] - MainProcess.CurrentTime).TotalSeconds
			});
			this.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.行会结盟,
				第一参数 = this.行会编号,
				第二参数 = 行会.行会编号,
				事记时间 = ComputingClass.TimeShift(MainProcess.CurrentTime)
			});
			行会.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.行会结盟,
				第一参数 = 行会.行会编号,
				第二参数 = this.行会编号,
				事记时间 = ComputingClass.TimeShift(MainProcess.CurrentTime)
			});
		}

		
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
				事记时间 = ComputingClass.TimeShift(MainProcess.CurrentTime)
			});
			行会.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.取消结盟,
				第一参数 = 行会.行会编号,
				第二参数 = this.行会编号,
				事记时间 = ComputingClass.TimeShift(MainProcess.CurrentTime)
			});
			SConnection 网络连接 = 主事.ActiveConnection;
			if (网络连接 == null)
			{
				return;
			}
			网络连接.发送封包(new 社交错误提示
			{
				错误编号 = 6812
			});
		}

		
		public void 申请解敌(CharacterData 主事, GuildData Hostility行会)
		{
			主事.ActiveConnection.发送封包(new 社交错误提示
			{
				错误编号 = 6829
			});
			foreach (KeyValuePair<CharacterData, GuildJobs> keyValuePair in Hostility行会.行会成员)
			{
				if (keyValuePair.Value <= GuildJobs.副长)
				{
					SConnection 网络连接 = keyValuePair.Key.ActiveConnection;
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
			Hostility行会.解除申请[this] = MainProcess.CurrentTime.AddHours(10.0);
		}

		
		public void 解除Hostility(GuildData 行会)
		{
			this.Hostility行会.Remove(行会);
			行会.Hostility行会.Remove(this);
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
				MemorandumType = MemorandumType.取消Hostility,
				第一参数 = this.行会编号,
				第二参数 = 行会.行会编号,
				事记时间 = ComputingClass.TimeShift(MainProcess.CurrentTime)
			});
			行会.添加事记(new GuildEvents
			{
				MemorandumType = MemorandumType.取消Hostility,
				第一参数 = 行会.行会编号,
				第二参数 = this.行会编号,
				事记时间 = ComputingClass.TimeShift(MainProcess.CurrentTime)
			});
		}

		
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

		
		public void 行会提醒(GuildJobs 职位, byte 提醒类型)
		{
			foreach (KeyValuePair<CharacterData, GuildJobs> keyValuePair in this.行会成员)
			{
				SConnection 客户网络;
				if (keyValuePair.Value <= 职位 && keyValuePair.Key.角色在线(out 客户网络))
				{
					客户网络.发送封包(new SendGuildNoticePacket
					{
						提醒类型 = 提醒类型
					});
				}
			}
		}

		
		public byte[] 行会检索描述()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream(new byte[229]))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(this.行会编号);
					byte[] array = new byte[25];
					Encoding.UTF8.GetBytes(this.GuildName.V).CopyTo(array, 0);
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

		
		public byte[] 行会信息描述()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(this.行会编号);
					binaryWriter.Write(Encoding.UTF8.GetBytes(this.GuildName.V));
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
						binaryWriter.Write(keyValuePair.Key.Id);
						byte[] array = new byte[32];
						Encoding.UTF8.GetBytes(keyValuePair.Key.CharName.V).CopyTo(array, 0);
						binaryWriter.Write(array);
						binaryWriter.Write((byte)keyValuePair.Value);
						binaryWriter.Write(keyValuePair.Key.角色等级);
						binaryWriter.Write((byte)keyValuePair.Key.CharRole.V);
						binaryWriter.Write(keyValuePair.Key.CurrentMap.V);
						SConnection 客户网络;
						binaryWriter.Write(keyValuePair.Key.角色在线(out 客户网络) ? 0 : ComputingClass.TimeShift(keyValuePair.Key.OfflineDate.V));
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
						binaryWriter.Write((byte)1);
						binaryWriter.Write(keyValuePair2.Key.行会编号);
						binaryWriter.Write(ComputingClass.TimeShift(keyValuePair2.Value));
						binaryWriter.Write(keyValuePair2.Key.行会等级.V);
						binaryWriter.Write((byte)keyValuePair2.Key.行会成员.Count);
						byte[] array2 = new byte[25];
						Encoding.UTF8.GetBytes(keyValuePair2.Key.GuildName.V).CopyTo(array2, 0);
						binaryWriter.Write(array2);
					}
					binaryWriter.Seek(1953, SeekOrigin.Begin);
					binaryWriter.Write((byte)this.Hostility行会.Count);
					foreach (KeyValuePair<GuildData, DateTime> keyValuePair3 in this.Hostility行会)
					{
						binaryWriter.Write((byte)2);
						binaryWriter.Write(keyValuePair3.Key.行会编号);
						binaryWriter.Write(ComputingClass.TimeShift(keyValuePair3.Value));
						binaryWriter.Write(keyValuePair3.Key.行会等级.V);
						binaryWriter.Write((byte)keyValuePair3.Key.行会成员.Count);
						byte[] array3 = new byte[25];
						Encoding.UTF8.GetBytes(keyValuePair3.Key.GuildName.V).CopyTo(array3, 0);
						binaryWriter.Write(array3);
					}
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		
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
						binaryWriter.Write(CharacterData.Id);
						byte[] array = new byte[32];
						Encoding.UTF8.GetBytes(CharacterData.CharName.V).CopyTo(array, 0);
						binaryWriter.Write(array);
						binaryWriter.Write(CharacterData.角色等级);
						binaryWriter.Write(CharacterData.角色等级);
						SConnection 客户网络;
						binaryWriter.Write(CharacterData.角色在线(out 客户网络) ? ComputingClass.TimeShift(MainProcess.CurrentTime) : ComputingClass.TimeShift(CharacterData.OfflineDate.V));
					}
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		
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
						Encoding.UTF8.GetBytes(keyValuePair.Key.GuildName.V).CopyTo(array, 0);
						binaryWriter.Write(array);
						binaryWriter.Write(keyValuePair.Key.行会等级.V);
						binaryWriter.Write((byte)keyValuePair.Key.行会成员.Count);
						array = new byte[32];
						Encoding.UTF8.GetBytes(keyValuePair.Key.会长名字).CopyTo(array, 0);
						binaryWriter.Write(array);
						binaryWriter.Write(ComputingClass.TimeShift(keyValuePair.Value.申请时间));
					}
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		
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

		
		public readonly DataMonitor<CharacterData> 行会会长;

		
		public readonly DataMonitor<DateTime> CreatedDate;

		
		public readonly DataMonitor<string> GuildName;

		
		public readonly DataMonitor<string> 创建人名;

		
		public readonly DataMonitor<string> 行会宣言;

		
		public readonly DataMonitor<string> 行会公告;

		
		public readonly DataMonitor<byte> 行会等级;

		
		public readonly DataMonitor<int> 行会资金;

		
		public readonly DataMonitor<int> 粮食数量;

		
		public readonly DataMonitor<int> 木材数量;

		
		public readonly DataMonitor<int> 石材数量;

		
		public readonly DataMonitor<int> 铁矿数量;

		
		public readonly DataMonitor<int> 行会排名;

		
		public readonly ListMonitor<GuildEvents> GuildEvents;

		
		public readonly MonitorDictionary<CharacterData, GuildJobs> 行会成员;

		
		public readonly MonitorDictionary<CharacterData, DateTime> 行会禁言;

		
		public readonly MonitorDictionary<GuildData, DateTime> 结盟行会;

		
		public readonly MonitorDictionary<GuildData, DateTime> Hostility行会;

		
		public Dictionary<CharacterData, DateTime> 申请列表;

		
		public Dictionary<CharacterData, DateTime> 邀请列表;

		
		public Dictionary<GuildData, DiplomaticApp> 结盟申请;

		
		public Dictionary<GuildData, DateTime> 解除申请;
	}
}
