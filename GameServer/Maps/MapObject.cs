using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using GameServer.Data;
using GameServer.Templates;
using GameServer.Networking;

namespace GameServer.Maps
{
	// Token: 0x020002D5 RID: 725
	public abstract class MapObject
	{
		// Token: 0x06000760 RID: 1888 RVA: 0x000064E7 File Offset: 0x000046E7
		public override string ToString()
		{
			return this.对象名字;
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000761 RID: 1889 RVA: 0x000064EF File Offset: 0x000046EF
		// (set) Token: 0x06000762 RID: 1890 RVA: 0x000064F7 File Offset: 0x000046F7
		public DateTime 恢复时间 { get; set; }

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000763 RID: 1891 RVA: 0x00006500 File Offset: 0x00004700
		// (set) Token: 0x06000764 RID: 1892 RVA: 0x00006508 File Offset: 0x00004708
		public DateTime 治疗时间 { get; set; }

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000765 RID: 1893 RVA: 0x00006511 File Offset: 0x00004711
		// (set) Token: 0x06000766 RID: 1894 RVA: 0x00006519 File Offset: 0x00004719
		public DateTime 脱战时间 { get; set; }

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000767 RID: 1895 RVA: 0x00006522 File Offset: 0x00004722
		// (set) Token: 0x06000768 RID: 1896 RVA: 0x0000652A File Offset: 0x0000472A
		public DateTime 处理计时 { get; set; }

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000769 RID: 1897 RVA: 0x00006533 File Offset: 0x00004733
		// (set) Token: 0x0600076A RID: 1898 RVA: 0x0000653B File Offset: 0x0000473B
		public DateTime 预约时间 { get; set; }

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600076B RID: 1899 RVA: 0x00006544 File Offset: 0x00004744
		public virtual int 处理间隔 { get; }

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x0600076C RID: 1900 RVA: 0x0000654C File Offset: 0x0000474C
		// (set) Token: 0x0600076D RID: 1901 RVA: 0x00006554 File Offset: 0x00004754
		public int 治疗次数 { get; set; }

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600076E RID: 1902 RVA: 0x0000655D File Offset: 0x0000475D
		// (set) Token: 0x0600076F RID: 1903 RVA: 0x00006565 File Offset: 0x00004765
		public int 治疗基数 { get; set; }

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000770 RID: 1904 RVA: 0x0000656E File Offset: 0x0000476E
		// (set) Token: 0x06000771 RID: 1905 RVA: 0x00006576 File Offset: 0x00004776
		public byte 动作编号 { get; set; }

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000772 RID: 1906 RVA: 0x0000657F File Offset: 0x0000477F
		// (set) Token: 0x06000773 RID: 1907 RVA: 0x00006587 File Offset: 0x00004787
		public bool 战斗姿态 { get; set; }

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000774 RID: 1908
		public abstract GameObjectType 对象类型 { get; }

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000775 RID: 1909
		public abstract 技能范围类型 对象体型 { get; }

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000776 RID: 1910 RVA: 0x00006590 File Offset: 0x00004790
		public ushort 行走速度
		{
			get
			{
				return (ushort)this[GameObjectProperties.行走速度];
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000777 RID: 1911 RVA: 0x0000659B File Offset: 0x0000479B
		public ushort 奔跑速度
		{
			get
			{
				return (ushort)this[GameObjectProperties.奔跑速度];
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000778 RID: 1912 RVA: 0x000065A6 File Offset: 0x000047A6
		public virtual int 行走耗时
		{
			get
			{
				return (int)(this.行走速度 * 60);
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000779 RID: 1913 RVA: 0x000065B1 File Offset: 0x000047B1
		public virtual int 奔跑耗时
		{
			get
			{
				return (int)(this.奔跑速度 * 60);
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x0600077A RID: 1914 RVA: 0x000065BC File Offset: 0x000047BC
		// (set) Token: 0x0600077B RID: 1915 RVA: 0x000065C4 File Offset: 0x000047C4
		public virtual int 地图编号 { get; set; }

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x0600077C RID: 1916 RVA: 0x000065CD File Offset: 0x000047CD
		// (set) Token: 0x0600077D RID: 1917 RVA: 0x000065D5 File Offset: 0x000047D5
		public virtual int 当前体力 { get; set; }

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x0600077E RID: 1918 RVA: 0x000065DE File Offset: 0x000047DE
		// (set) Token: 0x0600077F RID: 1919 RVA: 0x000065E6 File Offset: 0x000047E6
		public virtual int 当前魔力 { get; set; }

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000780 RID: 1920 RVA: 0x000065EF File Offset: 0x000047EF
		// (set) Token: 0x06000781 RID: 1921 RVA: 0x000065F7 File Offset: 0x000047F7
		public virtual byte 当前等级 { get; set; }

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000782 RID: 1922 RVA: 0x00006600 File Offset: 0x00004800
		// (set) Token: 0x06000783 RID: 1923 RVA: 0x00006608 File Offset: 0x00004808
		public virtual bool 对象死亡 { get; set; }

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000784 RID: 1924 RVA: 0x00006611 File Offset: 0x00004811
		// (set) Token: 0x06000785 RID: 1925 RVA: 0x00006619 File Offset: 0x00004819
		public virtual bool 阻塞网格 { get; set; }

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000786 RID: 1926 RVA: 0x00006622 File Offset: 0x00004822
		public virtual bool 能被命中
		{
			get
			{
				return !this.对象死亡;
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000787 RID: 1927 RVA: 0x0000662D File Offset: 0x0000482D
		// (set) Token: 0x06000788 RID: 1928 RVA: 0x00006635 File Offset: 0x00004835
		public virtual string 对象名字 { get; set; }

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000789 RID: 1929 RVA: 0x0000663E File Offset: 0x0000483E
		// (set) Token: 0x0600078A RID: 1930 RVA: 0x00006646 File Offset: 0x00004846
		public virtual GameDirection 当前方向 { get; set; }

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x0600078B RID: 1931 RVA: 0x0000664F File Offset: 0x0000484F
		// (set) Token: 0x0600078C RID: 1932 RVA: 0x00006657 File Offset: 0x00004857
		public virtual MapInstance 当前地图 { get; set; }

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x0600078D RID: 1933 RVA: 0x00006660 File Offset: 0x00004860
		// (set) Token: 0x0600078E RID: 1934 RVA: 0x00006668 File Offset: 0x00004868
		public virtual Point 当前坐标 { get; set; }

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x0600078F RID: 1935 RVA: 0x00006671 File Offset: 0x00004871
		public virtual ushort 当前高度
		{
			get
			{
				return this.当前地图.地形高度(this.当前坐标);
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000790 RID: 1936 RVA: 0x00006684 File Offset: 0x00004884
		// (set) Token: 0x06000791 RID: 1937 RVA: 0x0000668C File Offset: 0x0000488C
		public virtual DateTime 忙碌时间 { get; set; }

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000792 RID: 1938 RVA: 0x00006695 File Offset: 0x00004895
		// (set) Token: 0x06000793 RID: 1939 RVA: 0x0000669D File Offset: 0x0000489D
		public virtual DateTime 硬直时间 { get; set; }

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000794 RID: 1940 RVA: 0x000066A6 File Offset: 0x000048A6
		// (set) Token: 0x06000795 RID: 1941 RVA: 0x000066AE File Offset: 0x000048AE
		public virtual DateTime 行走时间 { get; set; }

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000796 RID: 1942 RVA: 0x000066B7 File Offset: 0x000048B7
		// (set) Token: 0x06000797 RID: 1943 RVA: 0x000066BF File Offset: 0x000048BF
		public virtual DateTime 奔跑时间 { get; set; }

		// Token: 0x1700010B RID: 267
		public virtual int this[GameObjectProperties 属性]
		{
			get
			{
				if (!this.当前属性.ContainsKey(属性))
				{
					return 0;
				}
				return this.当前属性[属性];
			}
			set
			{
				this.当前属性[属性] = value;
				if (属性 == GameObjectProperties.最大体力)
				{
					this.当前体力 = Math.Min(this.当前体力, value);
					return;
				}
				if (属性 == GameObjectProperties.最大魔力)
				{
					this.当前魔力 = Math.Min(this.当前魔力, value);
				}
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x0600079A RID: 1946 RVA: 0x00006724 File Offset: 0x00004924
		public virtual Dictionary<GameObjectProperties, int> 当前属性 { get; }

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x0600079B RID: 1947 RVA: 0x0000672C File Offset: 0x0000492C
		public virtual MonitorDictionary<int, DateTime> 冷却记录 { get; }

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x0600079C RID: 1948 RVA: 0x00006734 File Offset: 0x00004934
		public virtual MonitorDictionary<ushort, BuffData> Buff列表 { get; }

		// Token: 0x0600079D RID: 1949 RVA: 0x00039C38 File Offset: 0x00037E38
		public virtual void 更新对象属性()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			foreach (object obj in Enum.GetValues(typeof(GameObjectProperties)))
			{
				int num5 = 0;
				GameObjectProperties GameObjectProperties = (GameObjectProperties)obj;
				foreach (KeyValuePair<object, Dictionary<GameObjectProperties, int>> keyValuePair in this.属性加成)
				{
					int num6;
					if (keyValuePair.Value != null && keyValuePair.Value.TryGetValue(GameObjectProperties, out num6) && num6 != 0)
					{
						if (keyValuePair.Key is BuffData)
						{
							if (GameObjectProperties == GameObjectProperties.行走速度)
							{
								num2 = Math.Max(num2, num6);
								num = Math.Min(num, num6);
							}
							else if (GameObjectProperties == GameObjectProperties.奔跑速度)
							{
								num4 = Math.Max(num4, num6);
								num3 = Math.Min(num3, num6);
							}
							else
							{
								num5 += num6;
							}
						}
						else
						{
							num5 += num6;
						}
					}
				}
				if (GameObjectProperties == GameObjectProperties.行走速度)
				{
					this[GameObjectProperties] = Math.Max(1, num5 + num + num2);
				}
				else if (GameObjectProperties == GameObjectProperties.奔跑速度)
				{
					this[GameObjectProperties] = Math.Max(1, num5 + num3 + num4);
				}
				else if (GameObjectProperties == GameObjectProperties.幸运等级)
				{
					this[GameObjectProperties] = num5;
				}
				else
				{
					this[GameObjectProperties] = Math.Max(0, num5);
				}
			}
			PlayerObject PlayerObject = this as PlayerObject;
			if (PlayerObject != null)
			{
				foreach (PetObject PetObject in PlayerObject.宠物列表)
				{
					if (PetObject.对象模板.继承属性 != null)
					{
						Dictionary<GameObjectProperties, int> dictionary = new Dictionary<GameObjectProperties, int>();
						foreach (属性继承 属性继承 in PetObject.对象模板.继承属性)
						{
							dictionary[属性继承.转换属性] = (int)((float)this[属性继承.继承属性] * 属性继承.继承比例);
						}
						PetObject.属性加成[PlayerObject.CharacterData] = dictionary;
						PetObject.更新对象属性();
					}
				}
			}
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x0000673C File Offset: 0x0000493C
		public virtual void 处理对象数据()
		{
			this.处理计时 = MainProcess.当前时间;
			this.预约时间 = MainProcess.当前时间.AddMilliseconds((double)this.处理间隔);
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x00039EB4 File Offset: 0x000380B4
		public virtual void 自身死亡处理(MapObject 对象, bool 技能击杀)
		{
			this.发送封包(new ObjectCharacterDiesPacket
			{
				对象编号 = this.地图编号
			});
			this.技能任务.Clear();
			this.对象死亡 = true;
			this.阻塞网格 = false;
			foreach (MapObject MapObject in this.邻居列表.ToList<MapObject>())
			{
				MapObject.对象死亡时处理(this);
			}
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x00039F3C File Offset: 0x0003813C
		public MapObject()
		{
			
			
			this.处理计时 = MainProcess.当前时间;
			this.技能任务 = new HashSet<技能实例>();
			this.陷阱列表 = new HashSet<TrapObject>();
			this.重要邻居 = new HashSet<MapObject>();
			this.潜行邻居 = new HashSet<MapObject>();
			this.邻居列表 = new HashSet<MapObject>();
			this.当前属性 = new Dictionary<GameObjectProperties, int>();
			this.冷却记录 = new MonitorDictionary<int, DateTime>(null);
			this.Buff列表 = new MonitorDictionary<ushort, BuffData>(null);
			this.属性加成 = new Dictionary<object, Dictionary<GameObjectProperties, int>>();
			this.预约时间 = MainProcess.当前时间.AddMilliseconds((double)MainProcess.随机数.Next(this.处理间隔));
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x00039FE8 File Offset: 0x000381E8
		public void 解绑网格()
		{
			foreach (Point 坐标 in ComputingClass.技能范围(this.当前坐标, this.当前方向, this.对象体型))
			{
				this.当前地图[坐标].Remove(this);
			}
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x0003A038 File Offset: 0x00038238
		public void 绑定网格()
		{
			foreach (Point 坐标 in ComputingClass.技能范围(this.当前坐标, this.当前方向, this.对象体型))
			{
				this.当前地图[坐标].Add(this);
			}
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x00006760 File Offset: 0x00004960
		public void 删除对象()
		{
			this.清空邻居时处理();
			this.解绑网格();
			this.次要对象 = false;
			MapGatewayProcess.移除MapObject(this);
			this.激活对象 = false;
			MapGatewayProcess.移除激活对象(this);
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x00006788 File Offset: 0x00004988
		public int 网格距离(Point 坐标)
		{
			return ComputingClass.网格距离(this.当前坐标, 坐标);
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x00006796 File Offset: 0x00004996
		public int 网格距离(MapObject 对象)
		{
			return ComputingClass.网格距离(this.当前坐标, 对象.当前坐标);
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x0003A088 File Offset: 0x00038288
		public void 发送封包(GamePacket 封包)
		{
			string name = 封包.封包类型.Name;
			uint num = PrivateImplementationDetails.ComputeStringHash(name);
			if (num <= 1677418552U)
			{
				if (num <= 867000342U)
				{
					if (num <= 457456415U)
					{
						if (num != 181795477U)
						{
							if (num != 286644763U)
							{
								if (num != 457456415U)
								{
									goto IL_3ED;
								}
								if (!(name == "ObjectCharacterWalkPacket"))
								{
									goto IL_3ED;
								}
							}
							else if (!(name == "同步对象惩罚"))
							{
								goto IL_3ED;
							}
						}
						else if (!(name == "同步装配称号"))
						{
							goto IL_3ED;
						}
					}
					else if (num != 682079610U)
					{
						if (num != 789992525U)
						{
							if (num != 867000342U)
							{
								goto IL_3ED;
							}
							if (!(name == "ObjectCharacterRunPacket"))
							{
								goto IL_3ED;
							}
						}
						else if (!(name == "摆摊状态改变"))
						{
							goto IL_3ED;
						}
					}
					else if (!(name == "玩家名字变灰"))
					{
						goto IL_3ED;
					}
				}
				else if (num <= 1244045395U)
				{
					if (num != 995208877U)
					{
						if (num != 1093715955U)
						{
							if (num != 1244045395U)
							{
								goto IL_3ED;
							}
							if (!(name == "ObjectTransformTypePacket"))
							{
								goto IL_3ED;
							}
						}
						else if (!(name == "开始释放技能"))
						{
							goto IL_3ED;
						}
					}
					else if (!(name == "ObjectRotationDirectionPacket"))
					{
						goto IL_3ED;
					}
				}
				else if (num <= 1594795422U)
				{
					if (num != 1318025564U)
					{
						if (num != 1594795422U)
						{
							goto IL_3ED;
						}
						if (!(name == "同步角色外形"))
						{
							goto IL_3ED;
						}
					}
					else if (!(name == "变更摊位名字"))
					{
						goto IL_3ED;
					}
				}
				else if (num != 1606456126U)
				{
					if (num != 1677418552U)
					{
						goto IL_3ED;
					}
					if (!(name == "ObjectPassiveDisplacementPacket"))
					{
						goto IL_3ED;
					}
				}
				else if (!(name == "ObjectStateChangePacket"))
				{
					goto IL_3ED;
				}
			}
			else if (num <= 2428358173U)
			{
				if (num <= 1955236207U)
				{
					if (num != 1884402014U)
					{
						if (num != 1919523108U)
						{
							if (num != 1955236207U)
							{
								goto IL_3ED;
							}
							if (!(name == "触发命中特效"))
							{
								goto IL_3ED;
							}
						}
						else if (!(name == "CharacterLevelUpPacket"))
						{
							goto IL_3ED;
						}
					}
					else if (!(name == "同步对象体力"))
					{
						goto IL_3ED;
					}
				}
				else if (num <= 2096237972U)
				{
					if (num != 2003178529U)
					{
						if (num != 2096237972U)
						{
							goto IL_3ED;
						}
						if (!(name == "触发技能正常"))
						{
							goto IL_3ED;
						}
					}
					else if (!(name == "ObjectRemovalStatusPacket"))
					{
						goto IL_3ED;
					}
				}
				else if (num != 2315825355U)
				{
					if (num != 2428358173U)
					{
						goto IL_3ED;
					}
					if (!(name == "TrapMoveLocationPacket"))
					{
						goto IL_3ED;
					}
				}
				else if (!(name == "ReceiveChatMessagesNearbyPacket"))
				{
					goto IL_3ED;
				}
			}
			else if (num <= 2729930825U)
			{
				if (num != 2554277797U)
				{
					if (num != 2589561330U)
					{
						if (num != 2729930825U)
						{
							goto IL_3ED;
						}
						if (!(name == "SyncPetLevelPacket"))
						{
							goto IL_3ED;
						}
					}
					else if (!(name == "同步对象行会"))
					{
						goto IL_3ED;
					}
				}
				else if (!(name == "ObjectAddStatePacket"))
				{
					goto IL_3ED;
				}
			}
			else if (num <= 3590444028U)
			{
				if (num != 3477944711U)
				{
					if (num != 3590444028U)
					{
						goto IL_3ED;
					}
					if (!(name == "技能释放中断"))
					{
						goto IL_3ED;
					}
				}
				else if (!(name == "ObjectCharacterDiesPacket"))
				{
					goto IL_3ED;
				}
			}
			else if (num != 3880528933U)
			{
				if (num != 4257485605U)
				{
					goto IL_3ED;
				}
				if (!(name == "触发状态效果"))
				{
					goto IL_3ED;
				}
			}
			else if (!(name == "触发技能扩展"))
			{
				goto IL_3ED;
			}
			foreach (MapObject MapObject in this.邻居列表)
			{
				PlayerObject PlayerObject = MapObject as PlayerObject;
				if (PlayerObject != null && !PlayerObject.潜行邻居.Contains(this) && PlayerObject != null)
				{
					PlayerObject.网络连接.发送封包(封包);
				}
			}
			IL_3ED:
			PlayerObject PlayerObject2 = this as PlayerObject;
			if (PlayerObject2 != null)
			{
				客户网络 网络连接 = PlayerObject2.网络连接;
				if (网络连接 == null)
				{
					return;
				}
				网络连接.发送封包(封包);
			}
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x0003A4B0 File Offset: 0x000386B0
		public bool 在视线内(MapObject 对象)
		{
			return Math.Abs(this.当前坐标.X - 对象.当前坐标.X) <= 20 && Math.Abs(this.当前坐标.Y - 对象.当前坐标.Y) <= 20;
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x0003A50C File Offset: 0x0003870C
		public bool 主动攻击(MapObject 对象)
		{
			if (对象.对象死亡)
			{
				return false;
			}
			MonsterObject MonsterObject = this as MonsterObject;
			if (MonsterObject != null)
			{
				if (MonsterObject.主动攻击目标)
				{
					if (!(对象 is PlayerObject) && !(对象 is PetObject))
					{
						GuardInstance GuardInstance = 对象 as GuardInstance;
						if (GuardInstance == null || !GuardInstance.能否受伤)
						{
							return false;
						}
					}
					return true;
				}
			}
			else
			{
				GuardInstance GuardInstance2 = this as GuardInstance;
				if (GuardInstance2 != null)
				{
					if (!GuardInstance2.主动攻击目标)
					{
						return false;
					}
					MonsterObject MonsterObject2 = 对象 as MonsterObject;
					if (MonsterObject2 != null)
					{
						return MonsterObject2.主动攻击目标;
					}
					PlayerObject PlayerObject = 对象 as PlayerObject;
					if (PlayerObject != null)
					{
						return PlayerObject.红名玩家;
					}
					if (对象 is PetObject)
					{
						return GuardInstance2.模板编号 == 6734;
					}
				}
				else if (this is PetObject)
				{
					MonsterObject MonsterObject3 = 对象 as MonsterObject;
					return MonsterObject3 != null && MonsterObject3.主动攻击目标;
				}
			}
			return false;
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x0003A5CC File Offset: 0x000387CC
		public bool 邻居类型(MapObject 对象)
		{
			GameObjectType 对象类型 = this.对象类型;
			if (对象类型 <= GameObjectType.Npcc)
			{
				switch (对象类型)
				{
				case GameObjectType.玩家:
					return true;
				case GameObjectType.宠物:
				case GameObjectType.怪物:
				{
					GameObjectType 对象类型2 = 对象.对象类型;
					if (对象类型2 <= GameObjectType.怪物)
					{
						if (对象类型2 - GameObjectType.玩家 <= 1 || 对象类型2 == GameObjectType.怪物)
						{
							return true;
						}
					}
					else
					{
						if (对象类型2 == GameObjectType.Npcc)
						{
							return true;
						}
						if (对象类型2 == GameObjectType.陷阱)
						{
							return true;
						}
					}
					return false;
				}
				case (GameObjectType)3:
					break;
				default:
					if (对象类型 == GameObjectType.Npcc)
					{
						GameObjectType 对象类型2 = 对象.对象类型;
						if (对象类型2 - GameObjectType.玩家 > 1 && 对象类型2 != GameObjectType.怪物)
						{
							if (对象类型2 != GameObjectType.陷阱)
							{
								return false;
							}
						}
						return true;
					}
					break;
				}
			}
			else
			{
				if (对象类型 == GameObjectType.物品)
				{
					return 对象.对象类型 == GameObjectType.玩家;
				}
				if (对象类型 == GameObjectType.陷阱)
				{
					GameObjectType 对象类型2 = 对象.对象类型;
					if (对象类型2 - GameObjectType.玩家 > 1 && 对象类型2 != GameObjectType.怪物)
					{
						if (对象类型2 != GameObjectType.Npcc)
						{
							return false;
						}
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x0003A67C File Offset: 0x0003887C
		public 游戏对象关系 对象关系(MapObject 对象)
		{
			TrapObject TrapObject = 对象 as TrapObject;
			if (TrapObject != null)
			{
				对象 = TrapObject.陷阱来源;
			}
			if (this == 对象)
			{
				return 游戏对象关系.自身;
			}
			if (!(this is MonsterObject))
			{
				if (this is GuardInstance)
				{
					if (对象 is MonsterObject || 对象 is PetObject || 对象 is PlayerObject)
					{
						return 游戏对象关系.敌对;
					}
				}
				else
				{
					PlayerObject PlayerObject = this as PlayerObject;
					if (PlayerObject != null)
					{
						if (对象 is MonsterObject)
						{
							return 游戏对象关系.敌对;
						}
						if (对象 is GuardInstance)
						{
							if (PlayerObject.AttackMode == AttackMode.全体)
							{
								if (this.当前地图.地图编号 != 80)
								{
									return 游戏对象关系.敌对;
								}
							}
							return 游戏对象关系.友方;
						}
						PlayerObject PlayerObject2 = 对象 as PlayerObject;
						if (PlayerObject2 != null)
						{
							if (PlayerObject.AttackMode == AttackMode.和平)
							{
								return 游戏对象关系.友方;
							}
							if (PlayerObject.AttackMode == AttackMode.行会)
							{
								if (PlayerObject.所属行会 != null && PlayerObject2.所属行会 != null && (PlayerObject.所属行会 == PlayerObject2.所属行会 || PlayerObject.所属行会.结盟行会.ContainsKey(PlayerObject2.所属行会)))
								{
									return 游戏对象关系.友方;
								}
								return 游戏对象关系.敌对;
							}
							else
							{
								if (PlayerObject.AttackMode == AttackMode.组队)
								{
									if (PlayerObject.所属队伍 != null && PlayerObject2.所属队伍 != null)
									{
										if (PlayerObject.所属队伍 == PlayerObject2.所属队伍)
										{
											return 游戏对象关系.友方;
										}
									}
									return 游戏对象关系.敌对;
								}
								if (PlayerObject.AttackMode == AttackMode.全体)
								{
									return 游戏对象关系.敌对;
								}
								if (PlayerObject.AttackMode == AttackMode.善恶)
								{
									if (!PlayerObject2.红名玩家 && !PlayerObject2.灰名玩家)
									{
										return 游戏对象关系.友方;
									}
									return 游戏对象关系.敌对;
								}
								else if (PlayerObject.AttackMode == AttackMode.敌对)
								{
									if (PlayerObject.所属行会 != null && PlayerObject2.所属行会 != null && PlayerObject.所属行会.敌对行会.ContainsKey(PlayerObject2.所属行会))
									{
										return 游戏对象关系.敌对;
									}
									return 游戏对象关系.友方;
								}
							}
						}
						else
						{
							PetObject PetObject = 对象 as PetObject;
							if (PetObject != null)
							{
								if (PetObject.宠物主人 == PlayerObject)
								{
									if (PlayerObject.AttackMode != AttackMode.全体)
									{
										return 游戏对象关系.友方;
									}
									return 游戏对象关系.友方 | 游戏对象关系.敌对;
								}
								else
								{
									if (PlayerObject.AttackMode == AttackMode.和平)
									{
										return 游戏对象关系.友方;
									}
									if (PlayerObject.AttackMode == AttackMode.行会)
									{
										if (PlayerObject.所属行会 != null && PetObject.宠物主人.所属行会 != null && (PlayerObject.所属行会 == PetObject.宠物主人.所属行会 || PlayerObject.所属行会.结盟行会.ContainsKey(PetObject.宠物主人.所属行会)))
										{
											return 游戏对象关系.友方;
										}
										return 游戏对象关系.敌对;
									}
									else
									{
										if (PlayerObject.AttackMode == AttackMode.组队)
										{
											if (PlayerObject.所属队伍 != null && PetObject.宠物主人.所属队伍 != null)
											{
												if (PlayerObject.所属队伍 == PetObject.宠物主人.所属队伍)
												{
													return 游戏对象关系.友方;
												}
											}
											return 游戏对象关系.敌对;
										}
										if (PlayerObject.AttackMode == AttackMode.全体)
										{
											return 游戏对象关系.敌对;
										}
										if (PlayerObject.AttackMode == AttackMode.善恶)
										{
											if (!PetObject.宠物主人.红名玩家 && !PetObject.宠物主人.灰名玩家)
											{
												return 游戏对象关系.友方;
											}
											return 游戏对象关系.敌对;
										}
										else if (PlayerObject.AttackMode == AttackMode.敌对)
										{
											if (PlayerObject.所属行会 != null && PetObject.宠物主人.所属行会 != null && PlayerObject.所属行会.敌对行会.ContainsKey(PetObject.宠物主人.所属行会))
											{
												return 游戏对象关系.敌对;
											}
											return 游戏对象关系.友方;
										}
									}
								}
							}
						}
					}
					else
					{
						PetObject PetObject2 = this as PetObject;
						if (PetObject2 != null)
						{
							if (PetObject2.宠物主人 != 对象)
							{
								return PetObject2.宠物主人.对象关系(对象);
							}
							return 游戏对象关系.友方;
						}
						else
						{
							TrapObject TrapObject2 = this as TrapObject;
							if (TrapObject2 != null)
							{
								return TrapObject2.陷阱来源.对象关系(对象);
							}
						}
					}
				}
				return 游戏对象关系.自身;
			}
			if (!(对象 is MonsterObject))
			{
				return 游戏对象关系.敌对;
			}
			return 游戏对象关系.友方;
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x0003A970 File Offset: 0x00038B70
		public bool 特定类型(MapObject 来源, 指定目标类型 类型)
		{
			TrapObject TrapObject = 来源 as TrapObject;
			MapObject MapObject = (TrapObject != null) ? TrapObject.陷阱来源 : 来源;
			MonsterObject MonsterObject = this as MonsterObject;
			if (MonsterObject != null)
			{
				if (类型 == 指定目标类型.无)
				{
					return true;
				}
				if ((类型 & 指定目标类型.低级目标) == 指定目标类型.低级目标 && this.当前等级 < MapObject.当前等级)
				{
					return true;
				}
				if ((类型 & 指定目标类型.所有怪物) == 指定目标类型.所有怪物)
				{
					return true;
				}
				if ((类型 & 指定目标类型.低级怪物) == 指定目标类型.低级怪物 && this.当前等级 < MapObject.当前等级)
				{
					return true;
				}
				if ((类型 & 指定目标类型.低血怪物) == 指定目标类型.低血怪物 && (float)this.当前体力 / (float)this[GameObjectProperties.最大体力] < 0.4f)
				{
					return true;
				}
				if ((类型 & 指定目标类型.普通怪物) == 指定目标类型.普通怪物 && MonsterObject.怪物级别 == MonsterLevelType.普通怪物)
				{
					return true;
				}
				if ((类型 & 指定目标类型.不死生物) == 指定目标类型.不死生物 && MonsterObject.怪物种族 == MonsterRaceType.不死生物)
				{
					return true;
				}
				if ((类型 & 指定目标类型.虫族生物) == 指定目标类型.虫族生物 && MonsterObject.怪物种族 == MonsterRaceType.虫族生物)
				{
					return true;
				}
				if ((类型 & 指定目标类型.沃玛怪物) == 指定目标类型.沃玛怪物 && MonsterObject.怪物种族 == MonsterRaceType.沃玛怪物)
				{
					return true;
				}
				if ((类型 & 指定目标类型.猪类怪物) == 指定目标类型.猪类怪物 && MonsterObject.怪物种族 == MonsterRaceType.猪类怪物)
				{
					return true;
				}
				if ((类型 & 指定目标类型.祖玛怪物) == 指定目标类型.祖玛怪物 && MonsterObject.怪物种族 == MonsterRaceType.祖玛怪物)
				{
					return true;
				}
				if ((类型 & 指定目标类型.魔龙怪物) == 指定目标类型.魔龙怪物 && MonsterObject.怪物种族 == MonsterRaceType.魔龙怪物)
				{
					return true;
				}
				if ((类型 & 指定目标类型.精英怪物) == 指定目标类型.精英怪物 && (MonsterObject.怪物级别 == MonsterLevelType.精英干将 || MonsterObject.怪物级别 == MonsterLevelType.头目首领))
				{
					return true;
				}
				if ((类型 & 指定目标类型.背刺目标) == 指定目标类型.背刺目标)
				{
					GameDirection GameDirection = ComputingClass.计算方向(来源.当前坐标, this.当前坐标);
					GameDirection 当前方向 = this.当前方向;
					if (当前方向 <= GameDirection.上方)
					{
						if (当前方向 != GameDirection.左方)
						{
							if (当前方向 != GameDirection.左上)
							{
								if (当前方向 == GameDirection.上方)
								{
									if (GameDirection == GameDirection.左上 || GameDirection == GameDirection.上方 || GameDirection == GameDirection.右上)
									{
										return true;
									}
									return false;
								}
							}
							else
							{
								if (GameDirection == GameDirection.左方 || GameDirection == GameDirection.左上 || GameDirection == GameDirection.上方)
								{
									return true;
								}
								return false;
							}
						}
						else
						{
							if (GameDirection == GameDirection.左方 || GameDirection == GameDirection.左上 || GameDirection == GameDirection.左下)
							{
								return true;
							}
							return false;
						}
					}
					else if (当前方向 <= GameDirection.右方)
					{
						if (当前方向 != GameDirection.右上)
						{
							if (当前方向 == GameDirection.右方)
							{
								if (GameDirection == GameDirection.右上 || GameDirection == GameDirection.右方 || GameDirection == GameDirection.右下)
								{
									return true;
								}
								return false;
							}
						}
						else
						{
							if (GameDirection == GameDirection.上方 || GameDirection == GameDirection.右上 || GameDirection == GameDirection.右方)
							{
								return true;
							}
							return false;
						}
					}
					else if (当前方向 != GameDirection.下方)
					{
						if (当前方向 == GameDirection.左下)
						{
							if (GameDirection == GameDirection.左方 || GameDirection == GameDirection.下方 || GameDirection == GameDirection.左下)
							{
								return true;
							}
							return false;
						}
					}
					else
					{
						if (GameDirection == GameDirection.右下 || GameDirection == GameDirection.下方 || GameDirection == GameDirection.左下)
						{
							return true;
						}
						return false;
					}
					if (GameDirection == GameDirection.右方 || GameDirection == GameDirection.右下 || GameDirection == GameDirection.下方)
					{
						return true;
					}
				}
			}
			else if (this is GuardInstance)
			{
				if (类型 == 指定目标类型.无)
				{
					return true;
				}
				if ((类型 & 指定目标类型.低级目标) == 指定目标类型.低级目标 && this.当前等级 < MapObject.当前等级)
				{
					return true;
				}
				if ((类型 & 指定目标类型.背刺目标) == 指定目标类型.背刺目标)
				{
					GameDirection GameDirection2 = ComputingClass.计算方向(来源.当前坐标, this.当前坐标);
					GameDirection 当前方向 = this.当前方向;
					if (当前方向 <= GameDirection.上方)
					{
						if (当前方向 != GameDirection.左方)
						{
							if (当前方向 != GameDirection.左上)
							{
								if (当前方向 == GameDirection.上方)
								{
									if (GameDirection2 == GameDirection.左上 || GameDirection2 == GameDirection.上方 || GameDirection2 == GameDirection.右上)
									{
										return true;
									}
									return false;
								}
							}
							else
							{
								if (GameDirection2 == GameDirection.左方 || GameDirection2 == GameDirection.左上 || GameDirection2 == GameDirection.上方)
								{
									return true;
								}
								return false;
							}
						}
						else
						{
							if (GameDirection2 == GameDirection.左方 || GameDirection2 == GameDirection.左上 || GameDirection2 == GameDirection.左下)
							{
								return true;
							}
							return false;
						}
					}
					else if (当前方向 <= GameDirection.右方)
					{
						if (当前方向 != GameDirection.右上)
						{
							if (当前方向 == GameDirection.右方)
							{
								if (GameDirection2 == GameDirection.右上 || GameDirection2 == GameDirection.右方 || GameDirection2 == GameDirection.右下)
								{
									return true;
								}
								return false;
							}
						}
						else
						{
							if (GameDirection2 == GameDirection.上方 || GameDirection2 == GameDirection.右上 || GameDirection2 == GameDirection.右方)
							{
								return true;
							}
							return false;
						}
					}
					else if (当前方向 != GameDirection.下方)
					{
						if (当前方向 == GameDirection.左下)
						{
							if (GameDirection2 == GameDirection.左方 || GameDirection2 == GameDirection.下方 || GameDirection2 == GameDirection.左下)
							{
								return true;
							}
							return false;
						}
					}
					else
					{
						if (GameDirection2 == GameDirection.右下 || GameDirection2 == GameDirection.下方 || GameDirection2 == GameDirection.左下)
						{
							return true;
						}
						return false;
					}
					if (GameDirection2 == GameDirection.右方 || GameDirection2 == GameDirection.右下 || GameDirection2 == GameDirection.下方)
					{
						return true;
					}
				}
			}
			else
			{
				PetObject PetObject = this as PetObject;
				if (PetObject != null)
				{
					if (类型 == 指定目标类型.无)
					{
						return true;
					}
					if ((类型 & 指定目标类型.低级目标) == 指定目标类型.低级目标 && this.当前等级 < MapObject.当前等级)
					{
						return true;
					}
					if ((类型 & 指定目标类型.不死生物) == 指定目标类型.不死生物 && PetObject.宠物种族 == MonsterRaceType.不死生物)
					{
						return true;
					}
					if ((类型 & 指定目标类型.虫族生物) == 指定目标类型.虫族生物 && PetObject.宠物种族 == MonsterRaceType.虫族生物)
					{
						return true;
					}
					if ((类型 & 指定目标类型.所有宠物) == 指定目标类型.所有宠物)
					{
						return true;
					}
					if ((类型 & 指定目标类型.背刺目标) == 指定目标类型.背刺目标)
					{
						GameDirection GameDirection3 = ComputingClass.计算方向(来源.当前坐标, this.当前坐标);
						GameDirection 当前方向 = this.当前方向;
						if (当前方向 <= GameDirection.上方)
						{
							if (当前方向 != GameDirection.左方)
							{
								if (当前方向 != GameDirection.左上)
								{
									if (当前方向 == GameDirection.上方)
									{
										if (GameDirection3 == GameDirection.左上 || GameDirection3 == GameDirection.上方 || GameDirection3 == GameDirection.右上)
										{
											return true;
										}
										return false;
									}
								}
								else
								{
									if (GameDirection3 == GameDirection.左方 || GameDirection3 == GameDirection.左上 || GameDirection3 == GameDirection.上方)
									{
										return true;
									}
									return false;
								}
							}
							else
							{
								if (GameDirection3 == GameDirection.左方 || GameDirection3 == GameDirection.左上 || GameDirection3 == GameDirection.左下)
								{
									return true;
								}
								return false;
							}
						}
						else if (当前方向 <= GameDirection.右方)
						{
							if (当前方向 != GameDirection.右上)
							{
								if (当前方向 == GameDirection.右方)
								{
									if (GameDirection3 == GameDirection.右上 || GameDirection3 == GameDirection.右方 || GameDirection3 == GameDirection.右下)
									{
										return true;
									}
									return false;
								}
							}
							else
							{
								if (GameDirection3 == GameDirection.上方 || GameDirection3 == GameDirection.右上 || GameDirection3 == GameDirection.右方)
								{
									return true;
								}
								return false;
							}
						}
						else if (当前方向 != GameDirection.下方)
						{
							if (当前方向 == GameDirection.左下)
							{
								if (GameDirection3 == GameDirection.左方 || GameDirection3 == GameDirection.下方 || GameDirection3 == GameDirection.左下)
								{
									return true;
								}
								return false;
							}
						}
						else
						{
							if (GameDirection3 == GameDirection.右下 || GameDirection3 == GameDirection.下方 || GameDirection3 == GameDirection.左下)
							{
								return true;
							}
							return false;
						}
						if (GameDirection3 == GameDirection.右方 || GameDirection3 == GameDirection.右下 || GameDirection3 == GameDirection.下方)
						{
							return true;
						}
					}
				}
				else
				{
					PlayerObject PlayerObject = this as PlayerObject;
					if (PlayerObject != null)
					{
						if (类型 == 指定目标类型.无)
						{
							return true;
						}
						if ((类型 & 指定目标类型.低级目标) == 指定目标类型.低级目标 && this.当前等级 < MapObject.当前等级)
						{
							return true;
						}
						if ((类型 & 指定目标类型.带盾法师) == 指定目标类型.带盾法师 && PlayerObject.角色职业 == GameObjectProfession.法师 && PlayerObject.Buff列表.ContainsKey(25350))
						{
							return true;
						}
						if ((类型 & 指定目标类型.背刺目标) == 指定目标类型.背刺目标)
						{
							GameDirection GameDirection4 = ComputingClass.计算方向(来源.当前坐标, this.当前坐标);
							GameDirection 当前方向 = this.当前方向;
							if (当前方向 <= GameDirection.上方)
							{
								if (当前方向 != GameDirection.左方)
								{
									if (当前方向 != GameDirection.左上)
									{
										if (当前方向 == GameDirection.上方)
										{
											if (GameDirection4 == GameDirection.左上 || GameDirection4 == GameDirection.上方 || GameDirection4 == GameDirection.右上)
											{
												return true;
											}
											goto IL_7A8;
										}
									}
									else
									{
										if (GameDirection4 == GameDirection.左方 || GameDirection4 == GameDirection.左上 || GameDirection4 == GameDirection.上方)
										{
											return true;
										}
										goto IL_7A8;
									}
								}
								else
								{
									if (GameDirection4 == GameDirection.左方 || GameDirection4 == GameDirection.左上 || GameDirection4 == GameDirection.左下)
									{
										return true;
									}
									goto IL_7A8;
								}
							}
							else if (当前方向 <= GameDirection.右方)
							{
								if (当前方向 != GameDirection.右上)
								{
									if (当前方向 == GameDirection.右方)
									{
										if (GameDirection4 == GameDirection.右上 || GameDirection4 == GameDirection.右方 || GameDirection4 == GameDirection.右下)
										{
											return true;
										}
										goto IL_7A8;
									}
								}
								else
								{
									if (GameDirection4 == GameDirection.上方 || GameDirection4 == GameDirection.右上 || GameDirection4 == GameDirection.右方)
									{
										return true;
									}
									goto IL_7A8;
								}
							}
							else if (当前方向 != GameDirection.下方)
							{
								if (当前方向 == GameDirection.左下)
								{
									if (GameDirection4 == GameDirection.左方 || GameDirection4 == GameDirection.下方 || GameDirection4 == GameDirection.左下)
									{
										return true;
									}
									goto IL_7A8;
								}
							}
							else
							{
								if (GameDirection4 == GameDirection.右下 || GameDirection4 == GameDirection.下方 || GameDirection4 == GameDirection.左下)
								{
									return true;
								}
								goto IL_7A8;
							}
							if (GameDirection4 == GameDirection.右方 || GameDirection4 == GameDirection.右下 || GameDirection4 == GameDirection.下方)
							{
								return true;
							}
						}
						IL_7A8:
						if ((类型 & 指定目标类型.所有玩家) == 指定目标类型.所有玩家)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x0003B138 File Offset: 0x00039338
		public virtual bool 能否走动()
		{
			return !this.对象死亡 && !(MainProcess.当前时间 < this.忙碌时间) && !(MainProcess.当前时间 < this.行走时间) && !this.检查状态(游戏对象状态.忙绿状态 | 游戏对象状态.定身状态 | 游戏对象状态.麻痹状态 | 游戏对象状态.失神状态);
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x0003B188 File Offset: 0x00039388
		public virtual bool 能否跑动()
		{
			return !this.对象死亡 && !(MainProcess.当前时间 < this.忙碌时间) && !(MainProcess.当前时间 < this.奔跑时间) && !this.检查状态(游戏对象状态.忙绿状态 | 游戏对象状态.残废状态 | 游戏对象状态.定身状态 | 游戏对象状态.麻痹状态 | 游戏对象状态.失神状态);
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x0003B1D8 File Offset: 0x000393D8
		public virtual bool 能否转动()
		{
			return !this.对象死亡 && !(MainProcess.当前时间 < this.忙碌时间) && !(MainProcess.当前时间 < this.行走时间) && !this.检查状态(游戏对象状态.忙绿状态 | 游戏对象状态.麻痹状态 | 游戏对象状态.失神状态);
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x0003B228 File Offset: 0x00039428
		public virtual bool 能被推动(MapObject 来源)
		{
			if (this == 来源)
			{
				return true;
			}
			if (this is GuardInstance)
			{
				return false;
			}
			if (this.当前等级 >= 来源.当前等级)
			{
				return false;
			}
			MonsterObject MonsterObject = this as MonsterObject;
			return (MonsterObject == null || MonsterObject.可被技能推动) && 来源.对象关系(this) == 游戏对象关系.敌对;
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x0003B278 File Offset: 0x00039478
		public virtual bool 能否位移(MapObject 来源, Point 锚点, int 距离, int 数量, bool 穿墙, out Point 终点, out MapObject[] 目标)
		{
			终点 = this.当前坐标;
			目标 = null;
			if (!(this.当前坐标 == 锚点) && this.能被推动(来源))
			{
				List<MapObject> list = new List<MapObject>();
				for (int i = 1; i <= 距离; i++)
				{
					if (穿墙)
					{
						Point point = ComputingClass.前方坐标(this.当前坐标, 锚点, i);
						if (this.当前地图.能否通行(point))
						{
							终点 = point;
						}
					}
					else
					{
						GameDirection 方向 = ComputingClass.计算方向(this.当前坐标, 锚点);
						Point point2 = ComputingClass.前方坐标(this.当前坐标, 锚点, i);
						if (this.当前地图.地形阻塞(point2))
						{
							break;
						}
						bool flag = false;
						if (!this.当前地图.空间阻塞(point2))
						{
							goto IL_168;
						}
						using (IEnumerator<MapObject> enumerator = (from O in this.当前地图[point2]
						where O.阻塞网格
						select O).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								MapObject MapObject = enumerator.Current;
								if (list.Count >= 数量)
								{
									flag = true;
									break;
								}
								Point point3;
								MapObject[] collection;
								if (!MapObject.能否位移(来源, ComputingClass.前方坐标(MapObject.当前坐标, 方向, 1), 1, 数量 - list.Count - 1, false, out point3, out collection))
								{
									flag = true;
									break;
								}
								list.Add(MapObject);
								list.AddRange(collection);
							}
							goto IL_168;
						}
						IL_155:
						终点 = point2;
						goto IL_15D;
						IL_168:
						if (flag)
						{
							break;
						}
						goto IL_155;
					}
					IL_15D:;
				}
				目标 = list.ToArray();
				return 终点 != this.当前坐标;
			}
			return false;
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x0003B420 File Offset: 0x00039620
		public virtual bool 检查状态(游戏对象状态 待检状态)
		{
			foreach (BuffData BuffData in this.Buff列表.Values)
			{
				if ((BuffData.Buff效果 & Buff效果类型.状态标志) != Buff效果类型.技能标志 && (BuffData.Buff模板.角色所处状态 & 待检状态) != 游戏对象状态.正常状态)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x0003B48C File Offset: 0x0003968C
		public void 添加Buff时处理(ushort 编号, MapObject 来源)
		{
			if (!(this is ItemObject) && !(this is TrapObject))
			{
				GuardInstance GuardInstance = this as GuardInstance;
				if (GuardInstance == null || GuardInstance.能否受伤)
				{
					TrapObject TrapObject = 来源 as TrapObject;
					if (TrapObject != null)
					{
						来源 = TrapObject.陷阱来源;
					}
					游戏Buff 游戏Buff;
					if (游戏Buff.DataSheet.TryGetValue(编号, out 游戏Buff))
					{
						if ((游戏Buff.Buff效果 & Buff效果类型.状态标志) != Buff效果类型.技能标志)
						{
							if (((游戏Buff.角色所处状态 & 游戏对象状态.隐身状态) != 游戏对象状态.正常状态 || (游戏Buff.角色所处状态 & 游戏对象状态.潜行状态) != 游戏对象状态.正常状态) && this.检查状态(游戏对象状态.暴露状态))
							{
								return;
							}
							if ((游戏Buff.角色所处状态 & 游戏对象状态.暴露状态) != 游戏对象状态.正常状态)
							{
								foreach (BuffData BuffData in this.Buff列表.Values.ToList<BuffData>())
								{
									if ((BuffData.Buff模板.角色所处状态 & 游戏对象状态.隐身状态) != 游戏对象状态.正常状态 || (BuffData.Buff模板.角色所处状态 & 游戏对象状态.潜行状态) != 游戏对象状态.正常状态)
									{
										this.移除Buff时处理(BuffData.Buff编号.V);
									}
								}
							}
						}
						if ((游戏Buff.Buff效果 & Buff效果类型.造成伤害) != Buff效果类型.技能标志 && 游戏Buff.Buff伤害类型 == 技能伤害类型.灼烧 && this.Buff列表.ContainsKey(25352))
						{
							return;
						}
						ushort 分组编号 = (游戏Buff.分组编号 != 0) ? 游戏Buff.分组编号 : 游戏Buff.Buff编号;
						BuffData BuffData2 = null;
						switch (游戏Buff.叠加类型)
						{
						case Buff叠加类型.禁止叠加:
							if (this.Buff列表.Values.FirstOrDefault((BuffData O) => O.Buff分组 == 分组编号) == null)
							{
								BuffData2 = (this.Buff列表[游戏Buff.Buff编号] = new BuffData(来源, this, 游戏Buff.Buff编号));
							}
							break;
						case Buff叠加类型.同类替换:
						{
							IEnumerable<BuffData> values = this.Buff列表.Values;
							Func<BuffData, bool> predicate=null;

							if (predicate == null)
							{
								predicate  = ((BuffData O) => O.Buff分组 == 分组编号);
							}
							foreach (BuffData BuffData3 in values.Where(predicate).ToList<BuffData>())
							{
								this.移除Buff时处理(BuffData3.Buff编号.V);
							}
							BuffData2 = (this.Buff列表[游戏Buff.Buff编号] = new BuffData(来源, this, 游戏Buff.Buff编号));
							break;
						}
						case Buff叠加类型.同类叠加:
						{
							BuffData BuffData4;
							if (this.Buff列表.TryGetValue(编号, out BuffData4))
							{
								BuffData4.当前层数.V = (byte)Math.Min(BuffData4.当前层数.V + 1, BuffData4.最大层数);
								游戏Buff 游戏Buff2;
								if (游戏Buff.Buff允许合成 && BuffData4.当前层数.V >= 游戏Buff.Buff合成层数 && 游戏Buff.DataSheet.TryGetValue(游戏Buff.Buff合成编号, out 游戏Buff2))
								{
									this.移除Buff时处理(BuffData4.Buff编号.V);
									this.添加Buff时处理(游戏Buff.Buff合成编号, 来源);
								}
								else
								{
									BuffData4.剩余时间.V = BuffData4.持续时间.V;
									if (BuffData4.Buff同步)
									{
										this.发送封包(new ObjectStateChangePacket
										{
											对象编号 = this.地图编号,
											Buff编号 = BuffData4.Buff编号.V,
											Buff索引 = (int)BuffData4.Buff编号.V,
											当前层数 = BuffData4.当前层数.V,
											剩余时间 = (int)BuffData4.剩余时间.V.TotalMilliseconds,
											持续时间 = (int)BuffData4.持续时间.V.TotalMilliseconds
										});
									}
								}
							}
							else
							{
								BuffData2 = (this.Buff列表[游戏Buff.Buff编号] = new BuffData(来源, this, 游戏Buff.Buff编号));
							}
							break;
						}
						case Buff叠加类型.同类延时:
						{
							BuffData BuffData5;
							if (this.Buff列表.TryGetValue(编号, out BuffData5))
							{
								BuffData5.剩余时间.V += BuffData5.持续时间.V;
								if (BuffData5.Buff同步)
								{
									this.发送封包(new ObjectStateChangePacket
									{
										对象编号 = this.地图编号,
										Buff编号 = BuffData5.Buff编号.V,
										Buff索引 = (int)BuffData5.Buff编号.V,
										当前层数 = BuffData5.当前层数.V,
										剩余时间 = (int)BuffData5.剩余时间.V.TotalMilliseconds,
										持续时间 = (int)BuffData5.持续时间.V.TotalMilliseconds
									});
								}
							}
							else
							{
								BuffData2 = (this.Buff列表[游戏Buff.Buff编号] = new BuffData(来源, this, 游戏Buff.Buff编号));
							}
							break;
						}
						}
						if (BuffData2 != null)
						{
							if (BuffData2.Buff同步)
							{
								this.发送封包(new ObjectAddStatePacket
								{
									对象编号 = this.地图编号,
									Buff来源 = 来源.地图编号,
									Buff编号 = BuffData2.Buff编号.V,
									Buff索引 = (int)BuffData2.Buff编号.V,
									Buff层数 = BuffData2.当前层数.V,
									持续时间 = (int)BuffData2.持续时间.V.TotalMilliseconds
								});
							}
							if ((游戏Buff.Buff效果 & Buff效果类型.属性增减) != Buff效果类型.技能标志)
							{
								this.属性加成.Add(BuffData2, BuffData2.属性加成);
								this.更新对象属性();
							}
							if ((游戏Buff.Buff效果 & Buff效果类型.状态标志) != Buff效果类型.技能标志)
							{
								if ((游戏Buff.角色所处状态 & 游戏对象状态.隐身状态) != 游戏对象状态.正常状态)
								{
									foreach (MapObject MapObject in this.邻居列表.ToList<MapObject>())
									{
										MapObject.对象隐身时处理(this);
									}
								}
								if ((游戏Buff.角色所处状态 & 游戏对象状态.潜行状态) != 游戏对象状态.正常状态)
								{
									foreach (MapObject MapObject2 in this.邻居列表.ToList<MapObject>())
									{
										MapObject2.对象潜行时处理(this);
									}
								}
							}
							if (游戏Buff.连带Buff编号 != 0)
							{
								this.添加Buff时处理(游戏Buff.连带Buff编号, 来源);
							}
						}
					}
					return;
				}
			}
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x0003BAE0 File Offset: 0x00039CE0
		public void 移除Buff时处理(ushort 编号)
		{
			BuffData BuffData;
			if (this.Buff列表.TryGetValue(编号, out BuffData))
			{
				MapObject MapObject;
				if (BuffData.Buff模板.后接Buff编号 != 0 && BuffData.Buff来源 != null && MapGatewayProcess.MapObject表.TryGetValue(BuffData.Buff来源.地图编号, out MapObject) && MapObject == BuffData.Buff来源)
				{
					this.添加Buff时处理(BuffData.Buff模板.后接Buff编号, BuffData.Buff来源);
				}
				if (BuffData.依存列表 != null)
				{
					foreach (ushort 编号2 in BuffData.依存列表)
					{
						this.删除Buff时处理(编号2);
					}
				}
				if (BuffData.添加冷却 && BuffData.绑定技能 != 0 && BuffData.冷却时间 != 0)
				{
					PlayerObject PlayerObject = this as PlayerObject;
					if (PlayerObject != null && PlayerObject.主体技能表.ContainsKey(BuffData.绑定技能))
					{
						DateTime dateTime = MainProcess.当前时间.AddMilliseconds((double)BuffData.冷却时间);
						DateTime t = this.冷却记录.ContainsKey((int)BuffData.绑定技能 | 16777216) ? this.冷却记录[(int)BuffData.绑定技能 | 16777216] : default(DateTime);
						if (dateTime > t)
						{
							this.冷却记录[(int)BuffData.绑定技能 | 16777216] = dateTime;
							this.发送封包(new AddedSkillCooldownPacket
							{
								冷却编号 = ((int)BuffData.绑定技能 | 16777216),
								冷却时间 = (int)BuffData.冷却时间
							});
						}
					}
				}
				this.Buff列表.Remove(编号);
				BuffData.删除数据();
				if (BuffData.Buff同步)
				{
					this.发送封包(new ObjectRemovalStatusPacket
					{
						对象编号 = this.地图编号,
						Buff索引 = (int)编号
					});
				}
				if ((BuffData.Buff效果 & Buff效果类型.属性增减) != Buff效果类型.技能标志)
				{
					this.属性加成.Remove(BuffData);
					this.更新对象属性();
				}
				if ((BuffData.Buff效果 & Buff效果类型.状态标志) != Buff效果类型.技能标志)
				{
					if ((BuffData.Buff模板.角色所处状态 & 游戏对象状态.隐身状态) != 游戏对象状态.正常状态)
					{
						foreach (MapObject MapObject2 in this.邻居列表.ToList<MapObject>())
						{
							MapObject2.对象显隐时处理(this);
						}
					}
					if ((BuffData.Buff模板.角色所处状态 & 游戏对象状态.潜行状态) != 游戏对象状态.正常状态)
					{
						foreach (MapObject MapObject3 in this.邻居列表.ToList<MapObject>())
						{
							MapObject3.对象显行时处理(this);
						}
					}
				}
			}
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x0003BD78 File Offset: 0x00039F78
		public void 删除Buff时处理(ushort 编号)
		{
			BuffData BuffData;
			if (this.Buff列表.TryGetValue(编号, out BuffData))
			{
				if (BuffData.依存列表 != null)
				{
					foreach (ushort 编号2 in BuffData.依存列表)
					{
						this.删除Buff时处理(编号2);
					}
				}
				this.Buff列表.Remove(编号);
				BuffData.删除数据();
				if (BuffData.Buff同步)
				{
					this.发送封包(new ObjectRemovalStatusPacket
					{
						对象编号 = this.地图编号,
						Buff索引 = (int)编号
					});
				}
				if ((BuffData.Buff效果 & Buff效果类型.属性增减) != Buff效果类型.技能标志)
				{
					this.属性加成.Remove(BuffData);
					this.更新对象属性();
				}
				if ((BuffData.Buff效果 & Buff效果类型.状态标志) != Buff效果类型.技能标志)
				{
					if ((BuffData.Buff模板.角色所处状态 & 游戏对象状态.隐身状态) != 游戏对象状态.正常状态)
					{
						foreach (MapObject MapObject in this.邻居列表.ToList<MapObject>())
						{
							MapObject.对象显隐时处理(this);
						}
					}
					if ((BuffData.Buff模板.角色所处状态 & 游戏对象状态.潜行状态) != 游戏对象状态.正常状态)
					{
						foreach (MapObject MapObject2 in this.邻居列表.ToList<MapObject>())
						{
							MapObject2.对象显行时处理(this);
						}
					}
				}
			}
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x0003BEDC File Offset: 0x0003A0DC
		public void 轮询Buff时处理(BuffData 数据)
		{
			if (数据.到期消失 && (数据.剩余时间.V -= MainProcess.当前时间 - this.处理计时) < TimeSpan.Zero)
			{
				this.移除Buff时处理(数据.Buff编号.V);
				return;
			}
			if ((数据.处理计时.V -= MainProcess.当前时间 - this.处理计时) < TimeSpan.Zero)
			{
				数据.处理计时.V += TimeSpan.FromMilliseconds((double)数据.处理间隔);
				if ((数据.Buff效果 & Buff效果类型.造成伤害) != Buff效果类型.技能标志)
				{
					this.被动受伤时处理(数据);
				}
				if ((数据.Buff效果 & Buff效果类型.生命回复) != Buff效果类型.技能标志)
				{
					this.被动回复时处理(数据);
				}
			}
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x0003BFB4 File Offset: 0x0003A1B4
		public void 被技能命中处理(技能实例 技能, C_01_计算命中目标 参数)
		{
			TrapObject TrapObject = 技能.技能来源 as TrapObject;
			MapObject MapObject = (TrapObject != null) ? TrapObject.陷阱来源 : 技能.技能来源;
			if (技能.命中列表.ContainsKey(this.地图编号) || !this.能被命中)
			{
				return;
			}
			if (this != MapObject && !this.邻居列表.Contains(MapObject))
			{
				return;
			}
			if (技能.命中列表.Count >= 参数.限定命中数量)
			{
				return;
			}
			if ((参数.限定目标关系 & MapObject.对象关系(this)) == (游戏对象关系)0)
			{
				return;
			}
			if ((参数.限定目标类型 & this.对象类型) == (GameObjectType)0)
			{
				return;
			}
			if (!this.特定类型(技能.技能来源, 参数.限定特定类型))
			{
				return;
			}
			if ((参数.限定目标关系 & 游戏对象关系.敌对) != (游戏对象关系)0)
			{
				if (this.检查状态(游戏对象状态.无敌状态))
				{
					return;
				}
				if ((this is PlayerObject || this is PetObject) && (MapObject is PlayerObject || MapObject is PetObject) && (this.当前地图.安全区内(this.当前坐标) || MapObject.当前地图.安全区内(MapObject.当前坐标)))
				{
					return;
				}
				if (MapObject is MonsterObject && this.当前地图.安全区内(this.当前坐标))
				{
					return;
				}
			}
			MonsterObject MonsterObject = this as MonsterObject;
			if (MonsterObject != null && (MonsterObject.模板编号 == 8618 || MonsterObject.模板编号 == 8621))
			{
				PlayerObject PlayerObject = MapObject as PlayerObject;
				if (PlayerObject != null && PlayerObject.所属行会 != null && PlayerObject.所属行会 == SystemData.数据.占领行会.V)
				{
					return;
				}
				PetObject PetObject = MapObject as PetObject;
				if (PetObject != null && PetObject.宠物主人 != null && PetObject.宠物主人.所属行会 != null && PetObject.宠物主人.所属行会 == SystemData.数据.占领行会.V)
				{
					return;
				}
			}
			int num = 0;
			float num2 = 0f;
			int num3 = 0;
			float num4 = 0f;
			switch (参数.技能闪避方式)
			{
			case 技能闪避类型.技能无法闪避:
				num = 1;
				break;
			case 技能闪避类型.可被物理闪避:
				num3 = this[GameObjectProperties.物理敏捷];
				num = MapObject[GameObjectProperties.物理准确];
				if (this is MonsterObject)
				{
					num2 += (float)MapObject[GameObjectProperties.怪物命中] / 10000f;
				}
				if (MapObject is MonsterObject)
				{
					num4 += (float)this[GameObjectProperties.怪物闪避] / 10000f;
				}
				break;
			case 技能闪避类型.可被魔法闪避:
				num4 = (float)this[GameObjectProperties.魔法闪避] / 10000f;
				if (this is MonsterObject)
				{
					num2 += (float)MapObject[GameObjectProperties.怪物命中] / 10000f;
				}
				if (MapObject is MonsterObject)
				{
					num4 += (float)this[GameObjectProperties.怪物闪避] / 10000f;
				}
				break;
			case 技能闪避类型.可被中毒闪避:
				num4 = (float)this[GameObjectProperties.中毒躲避] / 10000f;
				break;
			case 技能闪避类型.非怪物可闪避:
				if (this is MonsterObject)
				{
					num = 1;
				}
				else
				{
					num3 = this[GameObjectProperties.物理敏捷];
					num = MapObject[GameObjectProperties.物理准确];
				}
				break;
			}
			命中详情 value = new 命中详情(this)
			{
				技能反馈 = (ComputingClass.计算命中((float)num, (float)num3, num2, num4) ? 参数.技能命中反馈 : 技能命中反馈.闪避)
			};
			技能.命中列表.Add(this.地图编号, value);
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x0003C2C0 File Offset: 0x0003A4C0
		public void 被动受伤时处理(技能实例 技能, C_02_计算目标伤害 参数, 命中详情 详情, float 伤害系数)
		{
			TrapObject TrapObject = 技能.技能来源 as TrapObject;
			MapObject MapObject = (TrapObject != null) ? TrapObject.陷阱来源 : 技能.技能来源;
			if (this.对象死亡)
			{
				详情.技能反馈 = 技能命中反馈.丢失;
			}
			else if (!this.邻居列表.Contains(MapObject))
			{
				详情.技能反馈 = 技能命中反馈.丢失;
			}
			else if ((MapObject.对象关系(this) & 游戏对象关系.敌对) == (游戏对象关系)0)
			{
				详情.技能反馈 = 技能命中反馈.丢失;
			}
			else
			{
				MonsterObject MonsterObject = this as MonsterObject;
				if (MonsterObject != null && (MonsterObject.模板编号 == 8618 || MonsterObject.模板编号 == 8621) && this.网格距离(MapObject) >= 4)
				{
					详情.技能反馈 = 技能命中反馈.丢失;
				}
			}
			if ((详情.技能反馈 & 技能命中反馈.免疫) == 技能命中反馈.正常 && (详情.技能反馈 & 技能命中反馈.丢失) == 技能命中反馈.正常)
			{
				if ((详情.技能反馈 & 技能命中反馈.闪避) == 技能命中反馈.正常)
				{
					if (参数.技能斩杀类型 != 指定目标类型.无 && ComputingClass.计算概率(参数.技能斩杀概率) && this.特定类型(MapObject, 参数.技能斩杀类型))
					{
						详情.技能伤害 = this.当前体力;
					}
					else
					{
						int[] 技能伤害基数 = 参数.技能伤害基数;
						int? num = (技能伤害基数 != null) ? new int?(技能伤害基数.Length) : null;
						int num2 = (int)技能.技能等级;
						int num3 = (num.GetValueOrDefault() > num2 & num != null) ? 参数.技能伤害基数[(int)技能.技能等级] : 0;
						float[] 技能伤害系数 = 参数.技能伤害系数;
						num = ((技能伤害系数 != null) ? new int?(技能伤害系数.Length) : null);
						num2 = (int)技能.技能等级;
						float num4 = (num.GetValueOrDefault() > num2 & num != null) ? 参数.技能伤害系数[(int)技能.技能等级] : 0f;
						if (this is MonsterObject)
						{
							num3 += MapObject[GameObjectProperties.怪物伤害];
						}
						int num5 = 0;
						float num6 = 0f;
						if (参数.技能增伤类型 != 指定目标类型.无 && this.特定类型(MapObject, 参数.技能增伤类型))
						{
							num5 = 参数.技能增伤基数;
							num6 = 参数.技能增伤系数;
						}
						int num7 = 0;
						float num8 = 0f;
						if (参数.技能破防概率 > 0f && ComputingClass.计算概率(参数.技能破防概率))
						{
							num7 = 参数.技能破防基数;
							num8 = 参数.技能破防系数;
						}
						int num9 = 0;
						int num10 = 0;
						switch (参数.技能伤害类型)
						{
						case 技能伤害类型.攻击:
							num10 = ComputingClass.计算防御(this[GameObjectProperties.最小防御], this[GameObjectProperties.最大防御]);
							num9 = ComputingClass.计算攻击(MapObject[GameObjectProperties.最小攻击], MapObject[GameObjectProperties.最大攻击], MapObject[GameObjectProperties.幸运等级]);
							break;
						case 技能伤害类型.魔法:
							num10 = ComputingClass.计算防御(this[GameObjectProperties.最小魔防], this[GameObjectProperties.最大魔防]);
							num9 = ComputingClass.计算攻击(MapObject[GameObjectProperties.最小魔法], MapObject[GameObjectProperties.最大魔法], MapObject[GameObjectProperties.幸运等级]);
							break;
						case 技能伤害类型.道术:
							num10 = ComputingClass.计算防御(this[GameObjectProperties.最小魔防], this[GameObjectProperties.最大魔防]);
							num9 = ComputingClass.计算攻击(MapObject[GameObjectProperties.最小道术], MapObject[GameObjectProperties.最大道术], MapObject[GameObjectProperties.幸运等级]);
							break;
						case 技能伤害类型.刺术:
							num10 = ComputingClass.计算防御(this[GameObjectProperties.最小防御], this[GameObjectProperties.最大防御]);
							num9 = ComputingClass.计算攻击(MapObject[GameObjectProperties.最小刺术], MapObject[GameObjectProperties.最大刺术], MapObject[GameObjectProperties.幸运等级]);
							break;
						case 技能伤害类型.弓术:
							num10 = ComputingClass.计算防御(this[GameObjectProperties.最小防御], this[GameObjectProperties.最大防御]);
							num9 = ComputingClass.计算攻击(MapObject[GameObjectProperties.最小弓术], MapObject[GameObjectProperties.最大弓术], MapObject[GameObjectProperties.幸运等级]);
							break;
						case 技能伤害类型.毒性:
							num9 = MapObject[GameObjectProperties.最大道术];
							break;
						case 技能伤害类型.神圣:
							num9 = ComputingClass.计算攻击(MapObject[GameObjectProperties.最小圣伤], MapObject[GameObjectProperties.最大圣伤], 0);
							break;
						}
						if (this is MonsterObject)
						{
							num10 = Math.Max(0, num10 - (int)((float)(num10 * MapObject[GameObjectProperties.怪物破防]) / 10000f));
						}
						int num11 = 0;
						float num12 = 0f;
						int num13 = int.MaxValue;
						foreach (BuffData BuffData in MapObject.Buff列表.Values.ToList<BuffData>())
						{
							if ((BuffData.Buff效果 & Buff效果类型.伤害增减) != Buff效果类型.技能标志 && (BuffData.Buff模板.效果判定方式 == Buff判定方式.主动攻击增伤 || BuffData.Buff模板.效果判定方式 == Buff判定方式.主动攻击减伤))
							{
								bool flag = false;
								switch (参数.技能伤害类型)
								{
								case 技能伤害类型.攻击:
								case 技能伤害类型.刺术:
								case 技能伤害类型.弓术:
								{
									Buff判定类型 效果判定类型 = BuffData.Buff模板.效果判定类型;
									if (效果判定类型 > Buff判定类型.所有物理伤害)
									{
										if (效果判定类型 == Buff判定类型.所有特定伤害)
										{
											HashSet<ushort> 特定技能编号 = BuffData.Buff模板.特定技能编号;
											flag = (特定技能编号 != null && 特定技能编号.Contains(技能.技能编号));
										}
									}
									else
									{
										flag = true;
									}
									break;
								}
								case 技能伤害类型.魔法:
								case 技能伤害类型.道术:
									switch (BuffData.Buff模板.效果判定类型)
									{
									case Buff判定类型.所有技能伤害:
									case Buff判定类型.所有魔法伤害:
										flag = true;
										break;
									case Buff判定类型.所有特定伤害:
									{
										HashSet<ushort> 特定技能编号2 = BuffData.Buff模板.特定技能编号;
										flag = (特定技能编号2 != null && 特定技能编号2.Contains(技能.技能编号));
										break;
									}
									}
									break;
								case 技能伤害类型.毒性:
								case 技能伤害类型.神圣:
								case 技能伤害类型.灼烧:
								case 技能伤害类型.撕裂:
									if (BuffData.Buff模板.效果判定类型 == Buff判定类型.所有特定伤害)
									{
										HashSet<ushort> 特定技能编号3 = BuffData.Buff模板.特定技能编号;
										flag = (特定技能编号3 != null && 特定技能编号3.Contains(技能.技能编号));
									}
									break;
								}
								if (flag)
								{
									int v = (int)BuffData.当前层数.V;
									int[] 伤害增减基数 = BuffData.Buff模板.伤害增减基数;
									num = ((伤害增减基数 != null) ? new int?(伤害增减基数.Length) : null);
									num2 = (int)BuffData.Buff等级.V;
									int num14 = v * ((num.GetValueOrDefault() > num2 & num != null) ? BuffData.Buff模板.伤害增减基数[(int)BuffData.Buff等级.V] : 0);
									float num15 = (float)BuffData.当前层数.V;
									float[] 伤害增减系数 = BuffData.Buff模板.伤害增减系数;
									num = ((伤害增减系数 != null) ? new int?(伤害增减系数.Length) : null);
									num2 = (int)BuffData.Buff等级.V;
									float num16 = num15 * ((num.GetValueOrDefault() > num2 & num != null) ? BuffData.Buff模板.伤害增减系数[(int)BuffData.Buff等级.V] : 0f);
									num11 += ((BuffData.Buff模板.效果判定方式 == Buff判定方式.主动攻击增伤) ? num14 : (-num14));
									num12 += ((BuffData.Buff模板.效果判定方式 == Buff判定方式.主动攻击增伤) ? num16 : (-num16));
									MapObject MapObject2;
									if (BuffData.Buff模板.生效后接编号 != 0 && BuffData.Buff来源 != null && MapGatewayProcess.MapObject表.TryGetValue(BuffData.Buff来源.地图编号, out MapObject2) && MapObject2 == BuffData.Buff来源)
									{
										if (BuffData.Buff模板.后接技能来源)
										{
											MapObject.添加Buff时处理(BuffData.Buff模板.生效后接编号, BuffData.Buff来源);
										}
										else
										{
											this.添加Buff时处理(BuffData.Buff模板.生效后接编号, BuffData.Buff来源);
										}
									}
									if (BuffData.Buff模板.效果生效移除)
									{
										MapObject.移除Buff时处理(BuffData.Buff编号.V);
									}
								}
							}
						}
						foreach (BuffData BuffData2 in this.Buff列表.Values.ToList<BuffData>())
						{
							if ((BuffData2.Buff效果 & Buff效果类型.伤害增减) != Buff效果类型.技能标志 && (BuffData2.Buff模板.效果判定方式 == Buff判定方式.被动受伤增伤 || BuffData2.Buff模板.效果判定方式 == Buff判定方式.被动受伤减伤))
							{
								bool flag2 = false;
								switch (参数.技能伤害类型)
								{
								case 技能伤害类型.攻击:
								case 技能伤害类型.刺术:
								case 技能伤害类型.弓术:
								{
									Buff判定类型 效果判定类型 = BuffData2.Buff模板.效果判定类型;
									if (效果判定类型 <= Buff判定类型.所有特定伤害)
									{
										if (效果判定类型 > Buff判定类型.所有物理伤害)
										{
											if (效果判定类型 == Buff判定类型.所有特定伤害)
											{
												HashSet<ushort> 特定技能编号4 = BuffData2.Buff模板.特定技能编号;
												flag2 = (特定技能编号4 != null && 特定技能编号4.Contains(技能.技能编号));
											}
										}
										else
										{
											flag2 = true;
										}
									}
									else if (效果判定类型 != Buff判定类型.来源技能伤害 && 效果判定类型 != Buff判定类型.来源物理伤害)
									{
										if (效果判定类型 == Buff判定类型.来源特定伤害)
										{
											bool flag3;
											if (MapObject == BuffData2.Buff来源)
											{
												HashSet<ushort> 特定技能编号5 = BuffData2.Buff模板.特定技能编号;
												flag3 = (特定技能编号5 != null && 特定技能编号5.Contains(技能.技能编号));
											}
											else
											{
												flag3 = false;
											}
											flag2 = flag3;
										}
									}
									else
									{
										flag2 = (MapObject == BuffData2.Buff来源);
									}
									break;
								}
								case 技能伤害类型.魔法:
								case 技能伤害类型.道术:
								{
									Buff判定类型 效果判定类型 = BuffData2.Buff模板.效果判定类型;
									if (效果判定类型 <= Buff判定类型.来源技能伤害)
									{
										switch (效果判定类型)
										{
										case Buff判定类型.所有技能伤害:
										case Buff判定类型.所有魔法伤害:
											flag2 = true;
											goto IL_953;
										case Buff判定类型.所有物理伤害:
										case (Buff判定类型)3:
											goto IL_953;
										case Buff判定类型.所有特定伤害:
											flag2 = BuffData2.Buff模板.特定技能编号.Contains(技能.技能编号);
											goto IL_953;
										default:
											if (效果判定类型 != Buff判定类型.来源技能伤害)
											{
												goto IL_953;
											}
											break;
										}
									}
									else if (效果判定类型 != Buff判定类型.来源魔法伤害)
									{
										if (效果判定类型 != Buff判定类型.来源特定伤害)
										{
											break;
										}
										bool flag4;
										if (MapObject == BuffData2.Buff来源)
										{
											HashSet<ushort> 特定技能编号6 = BuffData2.Buff模板.特定技能编号;
											flag4 = (特定技能编号6 != null && 特定技能编号6.Contains(技能.技能编号));
										}
										else
										{
											flag4 = false;
										}
										flag2 = flag4;
										break;
									}
									flag2 = (MapObject == BuffData2.Buff来源);
									break;
								}
								case 技能伤害类型.毒性:
								case 技能伤害类型.神圣:
								case 技能伤害类型.灼烧:
								case 技能伤害类型.撕裂:
								{
									Buff判定类型 效果判定类型 = BuffData2.Buff模板.效果判定类型;
									if (效果判定类型 != Buff判定类型.所有特定伤害)
									{
										if (效果判定类型 == Buff判定类型.来源特定伤害)
										{
											bool flag5;
											if (MapObject == BuffData2.Buff来源)
											{
												HashSet<ushort> 特定技能编号7 = BuffData2.Buff模板.特定技能编号;
												flag5 = (特定技能编号7 != null && 特定技能编号7.Contains(技能.技能编号));
											}
											else
											{
												flag5 = false;
											}
											flag2 = flag5;
										}
									}
									else
									{
										HashSet<ushort> 特定技能编号8 = BuffData2.Buff模板.特定技能编号;
										flag2 = (特定技能编号8 != null && 特定技能编号8.Contains(技能.技能编号));
									}
									break;
								}
								}
								IL_953:
								if (flag2)
								{
									int v2 = (int)BuffData2.当前层数.V;
									int[] 伤害增减基数2 = BuffData2.Buff模板.伤害增减基数;
									num = ((伤害增减基数2 != null) ? new int?(伤害增减基数2.Length) : null);
									num2 = (int)BuffData2.Buff等级.V;
									int num17 = v2 * ((num.GetValueOrDefault() > num2 & num != null) ? BuffData2.Buff模板.伤害增减基数[(int)BuffData2.Buff等级.V] : 0);
									float num18 = (float)BuffData2.当前层数.V;
									float[] 伤害增减系数2 = BuffData2.Buff模板.伤害增减系数;
									num = ((伤害增减系数2 != null) ? new int?(伤害增减系数2.Length) : null);
									num2 = (int)BuffData2.Buff等级.V;
									float num19 = num18 * ((num.GetValueOrDefault() > num2 & num != null) ? BuffData2.Buff模板.伤害增减系数[(int)BuffData2.Buff等级.V] : 0f);
									num11 += ((BuffData2.Buff模板.效果判定方式 == Buff判定方式.被动受伤增伤) ? num17 : (-num17));
									num12 += ((BuffData2.Buff模板.效果判定方式 == Buff判定方式.被动受伤增伤) ? num19 : (-num19));
									MapObject MapObject3;
									if (BuffData2.Buff模板.生效后接编号 != 0 && BuffData2.Buff来源 != null && MapGatewayProcess.MapObject表.TryGetValue(BuffData2.Buff来源.地图编号, out MapObject3) && MapObject3 == BuffData2.Buff来源)
									{
										if (BuffData2.Buff模板.后接技能来源)
										{
											MapObject.添加Buff时处理(BuffData2.Buff模板.生效后接编号, BuffData2.Buff来源);
										}
										else
										{
											this.添加Buff时处理(BuffData2.Buff模板.生效后接编号, BuffData2.Buff来源);
										}
									}
									if (BuffData2.Buff模板.效果判定方式 == Buff判定方式.被动受伤减伤 && BuffData2.Buff模板.限定伤害上限)
									{
										num13 = Math.Min(num13, BuffData2.Buff模板.限定伤害数值);
									}
									if (BuffData2.Buff模板.效果生效移除)
									{
										this.移除Buff时处理(BuffData2.Buff编号.V);
									}
								}
							}
						}
						float num20 = (num4 + num6) * (float)num9 + (float)num3 + (float)num5 + (float)num11;
						float val = (float)(num10 - num7) - (float)num10 * num8;
						float val2 = (num20 - Math.Max(0f, val)) * (1f + num12) * 伤害系数;
						int 技能伤害 = (int)Math.Min((float)num13, Math.Max(0f, val2));
						详情.技能伤害 = 技能伤害;
					}
				}
				this.脱战时间 = MainProcess.当前时间.AddSeconds(10.0);
				MapObject.脱战时间 = MainProcess.当前时间.AddSeconds(10.0);
				if ((详情.技能反馈 & 技能命中反馈.闪避) == 技能命中反馈.正常)
				{
					foreach (BuffData BuffData3 in this.Buff列表.Values.ToList<BuffData>())
					{
						if ((BuffData3.Buff效果 & Buff效果类型.状态标志) != Buff效果类型.技能标志 && (BuffData3.Buff模板.角色所处状态 & 游戏对象状态.失神状态) != 游戏对象状态.正常状态)
						{
							this.移除Buff时处理(BuffData3.Buff编号.V);
						}
					}
				}
				MonsterObject MonsterObject2 = this as MonsterObject;
				if (MonsterObject2 != null)
				{
					MonsterObject2.硬直时间 = MainProcess.当前时间.AddMilliseconds((double)参数.目标硬直时间);
					if (MapObject is PlayerObject || MapObject is PetObject)
					{
						MonsterObject2.HateObject.添加仇恨(MapObject, MainProcess.当前时间.AddMilliseconds((double)MonsterObject2.仇恨时长), 详情.技能伤害);
					}
				}
				else
				{
					PlayerObject PlayerObject = this as PlayerObject;
					if (PlayerObject != null)
					{
						if (详情.技能伤害 > 0)
						{
							PlayerObject.装备损失持久(详情.技能伤害);
						}
						if (详情.技能伤害 > 0)
						{
							PlayerObject.扣除护盾时间(详情.技能伤害);
						}
						if (PlayerObject.对象关系(MapObject) == 游戏对象关系.敌对)
						{
							foreach (PetObject PetObject in PlayerObject.宠物列表.ToList<PetObject>())
							{
								if (PetObject.邻居列表.Contains(MapObject) && !MapObject.检查状态(游戏对象状态.隐身状态 | 游戏对象状态.潜行状态))
								{
									PetObject.HateObject.添加仇恨(MapObject, MainProcess.当前时间.AddMilliseconds((double)PetObject.仇恨时长), 0);
								}
							}
						}
						PlayerObject PlayerObject2 = MapObject as PlayerObject;
						if (PlayerObject2 != null && !this.当前地图.自由区内(this.当前坐标) && !PlayerObject.灰名玩家 && !PlayerObject.红名玩家)
						{
							if (PlayerObject2.红名玩家)
							{
								PlayerObject2.减PK时间 = TimeSpan.FromMinutes(1.0);
							}
							else
							{
								PlayerObject2.灰名时间 = TimeSpan.FromMinutes(1.0);
							}
						}
						else
						{
							PetObject PetObject2 = MapObject as PetObject;
							if (PetObject2 != null && !this.当前地图.自由区内(this.当前坐标) && !PlayerObject.灰名玩家 && !PlayerObject.红名玩家)
							{
								if (PetObject2.宠物主人.红名玩家)
								{
									PetObject2.宠物主人.减PK时间 = TimeSpan.FromMinutes(1.0);
								}
								else
								{
									PetObject2.宠物主人.灰名时间 = TimeSpan.FromMinutes(1.0);
								}
							}
						}
					}
					else
					{
						PetObject PetObject3 = this as PetObject;
						if (PetObject3 != null)
						{
							if (MapObject != PetObject3.宠物主人 && PetObject3.对象关系(MapObject) == 游戏对象关系.敌对)
							{
								PlayerObject 宠物主人 = PetObject3.宠物主人;
								foreach (PetObject PetObject4 in ((宠物主人 != null) ? 宠物主人.宠物列表.ToList<PetObject>() : null))
								{
									if (PetObject4.邻居列表.Contains(MapObject) && !MapObject.检查状态(游戏对象状态.隐身状态 | 游戏对象状态.潜行状态))
									{
										PetObject4.HateObject.添加仇恨(MapObject, MainProcess.当前时间.AddMilliseconds((double)PetObject4.仇恨时长), 0);
									}
								}
							}
							if (MapObject != PetObject3.宠物主人)
							{
								PlayerObject PlayerObject3 = MapObject as PlayerObject;
								if (PlayerObject3 != null && !this.当前地图.自由区内(this.当前坐标) && !PetObject3.宠物主人.灰名玩家 && !PetObject3.宠物主人.红名玩家)
								{
									PlayerObject3.灰名时间 = TimeSpan.FromMinutes(1.0);
								}
							}
						}
						else
						{
							GuardInstance GuardInstance = this as GuardInstance;
							if (GuardInstance != null && GuardInstance.对象关系(MapObject) == 游戏对象关系.敌对)
							{
								GuardInstance.HateObject.添加仇恨(MapObject, default(DateTime), 0);
							}
						}
					}
				}
				PlayerObject PlayerObject4 = MapObject as PlayerObject;
				if (PlayerObject4 != null)
				{
					if (PlayerObject4.对象关系(this) == 游戏对象关系.敌对 && !this.检查状态(游戏对象状态.隐身状态 | 游戏对象状态.潜行状态))
					{
						foreach (PetObject PetObject5 in PlayerObject4.宠物列表.ToList<PetObject>())
						{
							if (PetObject5.邻居列表.Contains(this))
							{
								PetObject5.HateObject.添加仇恨(this, MainProcess.当前时间.AddMilliseconds((double)PetObject5.仇恨时长), 参数.增加宠物仇恨 ? 详情.技能伤害 : 0);
							}
						}
					}
					EquipmentData EquipmentData;
					if (MainProcess.当前时间 > PlayerObject4.战具计时 && !PlayerObject4.对象死亡 && PlayerObject4.当前体力 < PlayerObject4[GameObjectProperties.最大体力] && PlayerObject4.角色装备.TryGetValue(15, out EquipmentData) && EquipmentData.当前持久.V > 0 && (EquipmentData.物品编号 == 99999106 || EquipmentData.物品编号 == 99999107))
					{
						PlayerObject4.当前体力 += ((this is MonsterObject) ? 20 : 10);
						PlayerObject4.战具损失持久(1);
						PlayerObject4.战具计时 = MainProcess.当前时间.AddMilliseconds(1000.0);
					}
				}
				if ((this.当前体力 = Math.Max(0, this.当前体力 - 详情.技能伤害)) == 0)
				{
					详情.技能反馈 |= 技能命中反馈.死亡;
					this.自身死亡处理(MapObject, true);
				}
				return;
			}
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x0003D4A8 File Offset: 0x0003B6A8
		public void 被动受伤时处理(BuffData 数据)
		{
			int num = 0;
			switch (数据.伤害类型)
			{
			case 技能伤害类型.攻击:
			case 技能伤害类型.刺术:
			case 技能伤害类型.弓术:
				num = ComputingClass.计算防御(this[GameObjectProperties.最小防御], this[GameObjectProperties.最大防御]);
				break;
			case 技能伤害类型.魔法:
			case 技能伤害类型.道术:
				num = ComputingClass.计算防御(this[GameObjectProperties.最小魔防], this[GameObjectProperties.最大魔防]);
				break;
			}
			int num2 = Math.Max(0, 数据.伤害基数.V * (int)数据.当前层数.V - num);
			this.当前体力 = Math.Max(0, this.当前体力 - num2);
			触发状态效果 触发状态效果 = new 触发状态效果();
			触发状态效果.Buff编号 = 数据.Buff编号.V;
			MapObject buff来源 = 数据.Buff来源;
			触发状态效果.Buff来源 = ((buff来源 != null) ? buff来源.地图编号 : 0);
			触发状态效果.Buff目标 = this.地图编号;
			触发状态效果.血量变化 = -num2;
			this.发送封包(触发状态效果);
			if (this.当前体力 == 0)
			{
				this.自身死亡处理(数据.Buff来源, false);
			}
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x0003D598 File Offset: 0x0003B798
		public void 被动回复时处理(技能实例 技能, C_05_计算目标回复 参数)
		{
			if (!this.对象死亡)
			{
				if (this.当前地图 == 技能.技能来源.当前地图)
				{
					if (this != 技能.技能来源 && !this.邻居列表.Contains(技能.技能来源))
					{
						return;
					}
					TrapObject TrapObject = 技能.技能来源 as TrapObject;
					MapObject MapObject = (TrapObject != null) ? TrapObject.陷阱来源 : 技能.技能来源;
					int[] 体力回复次数 = 参数.体力回复次数;
					int? num = (体力回复次数 != null) ? new int?(体力回复次数.Length) : null;
					int 技能等级 = (int)技能.技能等级;
					int num2 = (num.GetValueOrDefault() > 技能等级 & num != null) ? 参数.体力回复次数[(int)技能.技能等级] : 0;
					byte[] 体力回复基数 = 参数.体力回复基数;
					num = ((体力回复基数 != null) ? new int?(体力回复基数.Length) : null);
					技能等级 = (int)技能.技能等级;
					int num3 = (int)((num.GetValueOrDefault() > 技能等级 & num != null) ? 参数.体力回复基数[(int)技能.技能等级] : 0);
					float[] 道术叠加次数 = 参数.道术叠加次数;
					num = ((道术叠加次数 != null) ? new int?(道术叠加次数.Length) : null);
					技能等级 = (int)技能.技能等级;
					float num4 = (num.GetValueOrDefault() > 技能等级 & num != null) ? 参数.道术叠加次数[(int)技能.技能等级] : 0f;
					float[] 道术叠加基数 = 参数.道术叠加基数;
					num = ((道术叠加基数 != null) ? new int?(道术叠加基数.Length) : null);
					技能等级 = (int)技能.技能等级;
					float num5 = (num.GetValueOrDefault() > 技能等级 & num != null) ? 参数.道术叠加基数[(int)技能.技能等级] : 0f;
					int[] 立即回复基数 = 参数.立即回复基数;
					num = ((立即回复基数 != null) ? new int?(立即回复基数.Length) : null);
					技能等级 = (int)技能.技能等级;
					int num6;
					if (num.GetValueOrDefault() > 技能等级 & num != null)
					{
						if (MapObject == this)
						{
							num6 = 参数.立即回复基数[(int)技能.技能等级];
							goto IL_1F1;
						}
					}
					num6 = 0;
					IL_1F1:
					int num7 = num6;
					float[] 立即回复系数 = 参数.立即回复系数;
					num = ((立即回复系数 != null) ? new int?(立即回复系数.Length) : null);
					技能等级 = (int)技能.技能等级;
					float num8;
					if (num.GetValueOrDefault() > 技能等级 & num != null)
					{
						if (MapObject == this)
						{
							num8 = 参数.立即回复系数[(int)技能.技能等级];
							goto IL_249;
						}
					}
					num8 = 0f;
					IL_249:
					float num9 = num8;
					if (num4 > 0f)
					{
						num2 += (int)(num4 * (float)ComputingClass.计算攻击(MapObject[GameObjectProperties.最小道术], MapObject[GameObjectProperties.最大道术], MapObject[GameObjectProperties.幸运等级]));
					}
					if (num5 > 0f)
					{
						num3 += (int)(num5 * (float)ComputingClass.计算攻击(MapObject[GameObjectProperties.最小道术], MapObject[GameObjectProperties.最大道术], MapObject[GameObjectProperties.幸运等级]));
					}
					if (num7 > 0)
					{
						this.当前体力 += num7;
					}
					if (num9 > 0f)
					{
						this.当前体力 += (int)((float)this[GameObjectProperties.最大体力] * num9);
					}
					if (num2 > this.治疗次数 && num3 > 0)
					{
						this.治疗次数 = (int)((byte)num2);
						this.治疗基数 = num3;
						this.治疗时间 = MainProcess.当前时间.AddMilliseconds(500.0);
					}
					return;
				}
			}
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x0003D8B8 File Offset: 0x0003BAB8
		public void 被动回复时处理(BuffData 数据)
		{
			if (数据.Buff模板.体力回复基数 == null)
			{
				return;
			}
			if (数据.Buff模板.体力回复基数.Length <= (int)数据.Buff等级.V)
			{
				return;
			}
			byte b = 数据.Buff模板.体力回复基数[(int)数据.Buff等级.V];
			this.当前体力 += (int)b;
			触发状态效果 触发状态效果 = new 触发状态效果();
			触发状态效果.Buff编号 = 数据.Buff编号.V;
			MapObject buff来源 = 数据.Buff来源;
			触发状态效果.Buff来源 = ((buff来源 != null) ? buff来源.地图编号 : 0);
			触发状态效果.Buff目标 = this.地图编号;
			触发状态效果.血量变化 = (int)b;
			this.发送封包(触发状态效果);
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x0003D95C File Offset: 0x0003BB5C
		public void 自身移动时处理(Point 坐标)
		{
			PlayerObject PlayerObject = this as PlayerObject;
			if (PlayerObject != null)
			{
				PlayerDeals 当前交易 = PlayerObject.当前交易;
				if (当前交易 != null)
				{
					当前交易.结束交易();
				}
				using (List<BuffData>.Enumerator enumerator = this.Buff列表.Values.ToList<BuffData>().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						BuffData BuffData = enumerator.Current;
						技能陷阱 陷阱模板;
						if ((BuffData.Buff效果 & Buff效果类型.创建陷阱) != Buff效果类型.技能标志 && 技能陷阱.DataSheet.TryGetValue(BuffData.Buff模板.触发陷阱技能, out 陷阱模板))
						{
							int num = 0;
							
							for (;;)
							{
								Point point = ComputingClass.前方坐标(this.当前坐标, 坐标, num);
								if (point == 坐标)
								{
									break;
								}
								foreach (Point 坐标2 in ComputingClass.技能范围(point, this.当前方向, BuffData.Buff模板.触发陷阱数量))
								{
									if (!this.当前地图.地形阻塞(坐标2))
									{
										IEnumerable<MapObject> source = this.当前地图[坐标2];
										Func<MapObject, bool> predicate=null;
										if (predicate == null)
										{
											predicate   = delegate(MapObject O)
											{
												TrapObject TrapObject = O as TrapObject;
												return TrapObject != null && TrapObject.陷阱分组编号 != 0 && TrapObject.陷阱分组编号 == 陷阱模板.分组编号;
											};
										}
										if (source.FirstOrDefault(predicate) == null)
										{
											this.陷阱列表.Add(new TrapObject(this, 陷阱模板, this.当前地图, 坐标2));
										}
									}
								}
								num++;
							}
						}
						if ((BuffData.Buff效果 & Buff效果类型.状态标志) != Buff效果类型.技能标志 && (BuffData.Buff模板.角色所处状态 & 游戏对象状态.隐身状态) != 游戏对象状态.正常状态)
						{
							this.移除Buff时处理(BuffData.Buff编号.V);
						}
					}
					goto IL_30E;
				}
			}
			if (this is PetObject)
			{
				foreach (BuffData BuffData2 in this.Buff列表.Values.ToList<BuffData>())
				{
					技能陷阱 陷阱模板;
					if ((BuffData2.Buff效果 & Buff效果类型.创建陷阱) != Buff效果类型.技能标志 && 技能陷阱.DataSheet.TryGetValue(BuffData2.Buff模板.触发陷阱技能, out 陷阱模板))
					{
						int num2 = 0;
						
						for (;;)
						{
							Point point2 = ComputingClass.前方坐标(this.当前坐标, 坐标, num2);
							if (point2 == 坐标)
							{
								break;
							}
							foreach (Point 坐标3 in ComputingClass.技能范围(point2, this.当前方向, BuffData2.Buff模板.触发陷阱数量))
							{
								if (!this.当前地图.地形阻塞(坐标3))
								{
									IEnumerable<MapObject> source2 = this.当前地图[坐标3];
									Func<MapObject, bool> predicate2 =null;
									if (predicate2  == null)
									{
										predicate2  = delegate(MapObject O)
										{
											TrapObject TrapObject = O as TrapObject;
											return TrapObject != null && TrapObject.陷阱分组编号 != 0 && TrapObject.陷阱分组编号 == 陷阱模板.分组编号;
										};
									}
									if (source2.FirstOrDefault(predicate2) == null)
									{
										this.陷阱列表.Add(new TrapObject(this, 陷阱模板, this.当前地图, 坐标3));
									}
								}
							}
							num2++;
						}
					}
					if ((BuffData2.Buff效果 & Buff效果类型.状态标志) != Buff效果类型.技能标志 && (BuffData2.Buff模板.角色所处状态 & 游戏对象状态.隐身状态) != 游戏对象状态.正常状态)
					{
						this.移除Buff时处理(BuffData2.Buff编号.V);
					}
				}
			}
			IL_30E:
			this.解绑网格();
			this.当前坐标 = 坐标;
			this.绑定网格();
			this.更新邻居时处理();
			foreach (MapObject MapObject in this.邻居列表.ToList<MapObject>())
			{
				MapObject.对象移动时处理(this);
			}
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x0003DD18 File Offset: 0x0003BF18
		public void 清空邻居时处理()
		{
			foreach (MapObject MapObject in this.邻居列表.ToList<MapObject>())
			{
				MapObject.对象消失时处理(this);
			}
			this.邻居列表.Clear();
			this.重要邻居.Clear();
			this.潜行邻居.Clear();
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x0003DD90 File Offset: 0x0003BF90
		public void 更新邻居时处理()
		{
			foreach (MapObject MapObject in this.邻居列表.ToList<MapObject>())
			{
				if (this.当前地图 != MapObject.当前地图 || !this.在视线内(MapObject))
				{
					MapObject.对象消失时处理(this);
					this.对象消失时处理(MapObject);
				}
			}
			for (int i = -20; i <= 20; i++)
			{
				for (int j = -20; j <= 20; j++)
				{
					this.当前地图[new Point(this.当前坐标.X + i, this.当前坐标.Y + j)].ToList<MapObject>();
					try
					{
						foreach (MapObject MapObject2 in this.当前地图[new Point(this.当前坐标.X + i, this.当前坐标.Y + j)])
						{
							if (MapObject2 != this)
							{
								if (!this.邻居列表.Contains(MapObject2) && this.邻居类型(MapObject2))
								{
									this.对象出现时处理(MapObject2);
								}
								if (!MapObject2.邻居列表.Contains(this) && MapObject2.邻居类型(this))
								{
									MapObject2.对象出现时处理(this);
								}
							}
						}
						goto IL_15C;
					}
					catch
					{
						goto IL_15C;
					}
					break;
					IL_15C:;
				}
			}
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x0003DF2C File Offset: 0x0003C12C
		public void 对象移动时处理(MapObject 对象)
		{
			if (!(this is ItemObject))
			{
				PetObject PetObject = this as PetObject;
				if (PetObject != null)
				{
					HateObject.仇恨详情 仇恨详情;
					if (PetObject.主动攻击(对象) && this.网格距离(对象) <= PetObject.仇恨范围 && !对象.检查状态(游戏对象状态.隐身状态 | 游戏对象状态.潜行状态))
					{
						PetObject.HateObject.添加仇恨(对象, default(DateTime), 0);
					}
					else if (this.网格距离(对象) > PetObject.仇恨范围 && PetObject.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情) && 仇恨详情.仇恨时间 < MainProcess.当前时间)
					{
						PetObject.HateObject.移除仇恨(对象);
					}
				}
				else
				{
					MonsterObject MonsterObject = this as MonsterObject;
					if (MonsterObject != null)
					{
						HateObject.仇恨详情 仇恨详情2;
						if (this.网格距离(对象) <= MonsterObject.仇恨范围 && MonsterObject.主动攻击(对象) && (MonsterObject.可见隐身目标 || !对象.检查状态(游戏对象状态.隐身状态 | 游戏对象状态.潜行状态)))
						{
							MonsterObject.HateObject.添加仇恨(对象, default(DateTime), 0);
						}
						else if (this.网格距离(对象) > MonsterObject.仇恨范围 && MonsterObject.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情2) && 仇恨详情2.仇恨时间 < MainProcess.当前时间)
						{
							MonsterObject.HateObject.移除仇恨(对象);
						}
					}
					else
					{
						TrapObject TrapObject = this as TrapObject;
						if (TrapObject != null)
						{
							if (ComputingClass.技能范围(TrapObject.当前坐标, TrapObject.当前方向, TrapObject.对象体型).Contains(对象.当前坐标))
							{
								TrapObject.被动触发陷阱(对象);
							}
						}
						else
						{
							GuardInstance GuardInstance = this as GuardInstance;
							if (GuardInstance != null)
							{
								if (GuardInstance.主动攻击(对象) && this.网格距离(对象) <= GuardInstance.仇恨范围)
								{
									GuardInstance.HateObject.添加仇恨(对象, default(DateTime), 0);
								}
								else if (this.网格距离(对象) > GuardInstance.仇恨范围)
								{
									GuardInstance.HateObject.移除仇恨(对象);
								}
							}
						}
					}
				}
			}
			if (!(对象 is ItemObject))
			{
				PetObject PetObject2 = 对象 as PetObject;
				if (PetObject2 != null)
				{
					if (PetObject2.网格距离(this) <= PetObject2.仇恨范围 && PetObject2.主动攻击(this) && !this.检查状态(游戏对象状态.隐身状态 | 游戏对象状态.潜行状态))
					{
						PetObject2.HateObject.添加仇恨(this, default(DateTime), 0);
						return;
					}
					HateObject.仇恨详情 仇恨详情3;
					if (PetObject2.网格距离(this) > PetObject2.仇恨范围 && PetObject2.HateObject.仇恨列表.TryGetValue(this, out 仇恨详情3) && 仇恨详情3.仇恨时间 < MainProcess.当前时间)
					{
						PetObject2.HateObject.移除仇恨(this);
						return;
					}
				}
				else
				{
					MonsterObject MonsterObject2 = 对象 as MonsterObject;
					if (MonsterObject2 != null)
					{
						if (MonsterObject2.网格距离(this) <= MonsterObject2.仇恨范围 && MonsterObject2.主动攻击(this) && (MonsterObject2.可见隐身目标 || !this.检查状态(游戏对象状态.隐身状态 | 游戏对象状态.潜行状态)))
						{
							MonsterObject2.HateObject.添加仇恨(this, default(DateTime), 0);
							return;
						}
						HateObject.仇恨详情 仇恨详情4;
						if (MonsterObject2.网格距离(this) > MonsterObject2.仇恨范围 && MonsterObject2.HateObject.仇恨列表.TryGetValue(this, out 仇恨详情4) && 仇恨详情4.仇恨时间 < MainProcess.当前时间)
						{
							MonsterObject2.HateObject.移除仇恨(this);
							return;
						}
					}
					else
					{
						TrapObject TrapObject2 = 对象 as TrapObject;
						if (TrapObject2 != null)
						{
							if (ComputingClass.技能范围(TrapObject2.当前坐标, TrapObject2.当前方向, TrapObject2.对象体型).Contains(this.当前坐标))
							{
								TrapObject2.被动触发陷阱(this);
								return;
							}
						}
						else
						{
							GuardInstance GuardInstance2 = 对象 as GuardInstance;
							if (GuardInstance2 != null)
							{
								if (GuardInstance2.主动攻击(this) && GuardInstance2.网格距离(this) <= GuardInstance2.仇恨范围)
								{
									GuardInstance2.HateObject.添加仇恨(this, default(DateTime), 0);
									return;
								}
								if (GuardInstance2.网格距离(this) > GuardInstance2.仇恨范围)
								{
									GuardInstance2.HateObject.移除仇恨(this);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x0003E308 File Offset: 0x0003C508
		public void 对象出现时处理(MapObject 对象)
		{
			if (this.潜行邻居.Remove(对象))
			{
				if (!(this is ItemObject))
				{
					PlayerObject PlayerObject = this as PlayerObject;
					if (PlayerObject != null)
					{
						GameObjectType 对象类型 = 对象.对象类型;
						if (对象类型 <= GameObjectType.Npcc)
						{
							switch (对象类型)
							{
							case GameObjectType.玩家:
							case GameObjectType.怪物:
								break;
							case GameObjectType.宠物:
								PlayerObject.网络连接.发送封包(new ObjectRoleStopPacket
								{
									对象编号 = 对象.地图编号,
									对象坐标 = 对象.当前坐标,
									对象高度 = 对象.当前高度
								});
								PlayerObject.网络连接.发送封包(new ObjectComesIntoViewPacket
								{
									出现方式 = 1,
									对象编号 = 对象.地图编号,
									现身坐标 = 对象.当前坐标,
									现身高度 = 对象.当前高度,
									现身方向 = (ushort)对象.当前方向,
									现身姿态 = ((byte)(对象.对象死亡 ? 13 : 1)),
									体力比例 = (byte)(对象.当前体力 * 100 / 对象[GameObjectProperties.最大体力])
								});
								PlayerObject.网络连接.发送封包(new 同步对象体力
								{
									对象编号 = 对象.地图编号,
									当前体力 = 对象.当前体力,
									体力上限 = 对象[GameObjectProperties.最大体力]
								});
								PlayerObject.网络连接.发送封包(new ObjectTransformTypePacket
								{
									改变类型 = 2,
									对象编号 = 对象.地图编号
								});
								goto IL_356;
							case (GameObjectType)3:
								goto IL_356;
							default:
								if (对象类型 != GameObjectType.Npcc)
								{
									goto IL_356;
								}
								break;
							}
							PlayerObject.网络连接.发送封包(new ObjectRoleStopPacket
							{
								对象编号 = 对象.地图编号,
								对象坐标 = 对象.当前坐标,
								对象高度 = 对象.当前高度
							});
							客户网络 网络连接 = PlayerObject.网络连接;
							ObjectComesIntoViewPacket ObjectComesIntoViewPacket = new ObjectComesIntoViewPacket();
							ObjectComesIntoViewPacket.出现方式 = 1;
							ObjectComesIntoViewPacket.对象编号 = 对象.地图编号;
							ObjectComesIntoViewPacket.现身坐标 = 对象.当前坐标;
							ObjectComesIntoViewPacket.现身高度 = 对象.当前高度;
							ObjectComesIntoViewPacket.现身方向 = (ushort)对象.当前方向;
							ObjectComesIntoViewPacket.现身姿态 = ((byte)(对象.对象死亡 ? 13 : 1));
							ObjectComesIntoViewPacket.体力比例 = (byte)(对象.当前体力 * 100 / 对象[GameObjectProperties.最大体力]);
							PlayerObject PlayerObject2 = 对象 as PlayerObject;
                            ObjectComesIntoViewPacket.补充参数 = ((byte)((PlayerObject2 == null || !PlayerObject2.灰名玩家) ? 0 : 2));
							网络连接.发送封包(ObjectComesIntoViewPacket);
							PlayerObject.网络连接.发送封包(new 同步对象体力
							{
								对象编号 = 对象.地图编号,
								当前体力 = 对象.当前体力,
								体力上限 = 对象[GameObjectProperties.最大体力]
							});
						}
						else if (对象类型 != GameObjectType.物品)
						{
							if (对象类型 == GameObjectType.陷阱)
							{
								PlayerObject.网络连接.发送封包(new TrapComesIntoViewPacket
								{
									地图编号 = 对象.地图编号,
									陷阱坐标 = 对象.当前坐标,
									陷阱高度 = 对象.当前高度,
									来源编号 = (对象 as TrapObject).陷阱来源.地图编号,
									陷阱编号 = (对象 as TrapObject).陷阱编号,
									持续时间 = (对象 as TrapObject).陷阱剩余时间
								});
							}
						}
						else
						{
							PlayerObject.网络连接.发送封包(new ObjectDropItemsPacket
							{
								对象编号 = 对象.地图编号,
								地图编号 = 对象.地图编号,
								掉落坐标 = 对象.当前坐标,
								掉落高度 = 对象.当前高度,
								物品编号 = (对象 as ItemObject).物品编号,
								物品数量 = (对象 as ItemObject).堆叠数量
							});
						}
						IL_356:
						if (对象.Buff列表.Count > 0)
						{
							PlayerObject.网络连接.发送封包(new 同步对象Buff
							{
								字节描述 = 对象.对象Buff简述()
							});
							return;
						}
					}
					else
					{
						TrapObject TrapObject = this as TrapObject;
						if (TrapObject != null)
						{
							if (ComputingClass.技能范围(TrapObject.当前坐标, TrapObject.当前方向, TrapObject.对象体型).Contains(对象.当前坐标))
							{
								TrapObject.被动触发陷阱(对象);
								return;
							}
						}
						else
						{
							PetObject PetObject = this as PetObject;
							if (PetObject != null)
							{
								if (this.网格距离(对象) <= PetObject.仇恨范围 && PetObject.主动攻击(对象) && !对象.检查状态(游戏对象状态.隐身状态 | 游戏对象状态.潜行状态))
								{
									PetObject.HateObject.添加仇恨(对象, default(DateTime), 0);
									return;
								}
								HateObject.仇恨详情 仇恨详情;
								if (this.网格距离(对象) > PetObject.仇恨范围 && PetObject.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情) && 仇恨详情.仇恨时间 < MainProcess.当前时间)
								{
									PetObject.HateObject.移除仇恨(对象);
									return;
								}
							}
							else
							{
								MonsterObject MonsterObject = this as MonsterObject;
								if (MonsterObject != null)
								{
									if (this.网格距离(对象) <= MonsterObject.仇恨范围 && MonsterObject.主动攻击(对象) && (MonsterObject.可见隐身目标 || !对象.检查状态(游戏对象状态.隐身状态 | 游戏对象状态.潜行状态)))
									{
										MonsterObject.HateObject.添加仇恨(对象, default(DateTime), 0);
										return;
									}
									HateObject.仇恨详情 仇恨详情2;
									if (this.网格距离(对象) > MonsterObject.仇恨范围 && MonsterObject.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情2) && 仇恨详情2.仇恨时间 < MainProcess.当前时间)
									{
										MonsterObject.HateObject.移除仇恨(对象);
										return;
									}
								}
							}
						}
					}
				}
			}
			else if (this.邻居列表.Add(对象))
			{
				if (对象 is PlayerObject || 对象 is PetObject)
				{
					this.重要邻居.Add(对象);
				}
				if (!(this is ItemObject))
				{
					PlayerObject PlayerObject3 = this as PlayerObject;
					if (PlayerObject3 != null)
					{
						GameObjectType 对象类型 = 对象.对象类型;
						if (对象类型 <= GameObjectType.Npcc)
						{
							switch (对象类型)
							{
							case GameObjectType.玩家:
							case GameObjectType.怪物:
								break;
							case GameObjectType.宠物:
								PlayerObject3.网络连接.发送封包(new ObjectRoleStopPacket
								{
									对象编号 = 对象.地图编号,
									对象坐标 = 对象.当前坐标,
									对象高度 = 对象.当前高度
								});
								PlayerObject3.网络连接.发送封包(new ObjectComesIntoViewPacket
								{
									出现方式 = 1,
									对象编号 = 对象.地图编号,
									现身坐标 = 对象.当前坐标,
									现身高度 = 对象.当前高度,
									现身方向 = (ushort)对象.当前方向,
									现身姿态 = ((byte)(对象.对象死亡 ? 13 : 1)),
									体力比例 = (byte)(对象.当前体力 * 100 / 对象[GameObjectProperties.最大体力])
								});
								PlayerObject3.网络连接.发送封包(new 同步对象体力
								{
									对象编号 = 对象.地图编号,
									当前体力 = 对象.当前体力,
									体力上限 = 对象[GameObjectProperties.最大体力]
								});
								PlayerObject3.网络连接.发送封包(new ObjectTransformTypePacket
								{
									改变类型 = 2,
									对象编号 = 对象.地图编号
								});
								goto IL_866;
							case (GameObjectType)3:
								goto IL_866;
							default:
								if (对象类型 != GameObjectType.Npcc)
								{
									goto IL_866;
								}
								break;
							}
							PlayerObject3.网络连接.发送封包(new ObjectRoleStopPacket
							{
								对象编号 = 对象.地图编号,
								对象坐标 = 对象.当前坐标,
								对象高度 = 对象.当前高度
							});
							客户网络 网络连接2 = PlayerObject3.网络连接;
							ObjectComesIntoViewPacket ObjectComesIntoViewPacket2 = new ObjectComesIntoViewPacket();
							ObjectComesIntoViewPacket2.出现方式 = 1;
							ObjectComesIntoViewPacket2.对象编号 = 对象.地图编号;
							ObjectComesIntoViewPacket2.现身坐标 = 对象.当前坐标;
							ObjectComesIntoViewPacket2.现身高度 = 对象.当前高度;
							ObjectComesIntoViewPacket2.现身方向 = (ushort)对象.当前方向;
							ObjectComesIntoViewPacket2.现身姿态 = ((byte)(对象.对象死亡 ? 13 : 1));
							ObjectComesIntoViewPacket2.体力比例 = (byte)(对象.当前体力 * 100 / 对象[GameObjectProperties.最大体力]);
							PlayerObject PlayerObject4 = 对象 as PlayerObject;
							ObjectComesIntoViewPacket2.补充参数 = ((byte)((PlayerObject4 == null || !PlayerObject4.灰名玩家) ? 0 : 2));
							网络连接2.发送封包(ObjectComesIntoViewPacket2);
							PlayerObject3.网络连接.发送封包(new 同步对象体力
							{
								对象编号 = 对象.地图编号,
								当前体力 = 对象.当前体力,
								体力上限 = 对象[GameObjectProperties.最大体力]
							});
						}
						else if (对象类型 != GameObjectType.物品)
						{
							if (对象类型 == GameObjectType.陷阱)
							{
								PlayerObject3.网络连接.发送封包(new TrapComesIntoViewPacket
								{
									地图编号 = 对象.地图编号,
									陷阱坐标 = 对象.当前坐标,
									陷阱高度 = 对象.当前高度,
									来源编号 = (对象 as TrapObject).陷阱来源.地图编号,
									陷阱编号 = (对象 as TrapObject).陷阱编号,
									持续时间 = (对象 as TrapObject).陷阱剩余时间
								});
							}
						}
						else
						{
							PlayerObject3.网络连接.发送封包(new ObjectDropItemsPacket
							{
								对象编号 = 对象.地图编号,
								地图编号 = 对象.地图编号,
								掉落坐标 = 对象.当前坐标,
								掉落高度 = 对象.当前高度,
								物品编号 = (对象 as ItemObject).物品编号,
								物品数量 = (对象 as ItemObject).堆叠数量
							});
						}
						IL_866:
						if (对象.Buff列表.Count > 0)
						{
							PlayerObject3.网络连接.发送封包(new 同步对象Buff
							{
								字节描述 = 对象.对象Buff简述()
							});
							return;
						}
					}
					else
					{
						TrapObject TrapObject2 = this as TrapObject;
						if (TrapObject2 != null)
						{
							if (ComputingClass.技能范围(TrapObject2.当前坐标, TrapObject2.当前方向, TrapObject2.对象体型).Contains(对象.当前坐标))
							{
								TrapObject2.被动触发陷阱(对象);
								return;
							}
						}
						else
						{
							PetObject PetObject2 = this as PetObject;
							if (PetObject2 != null && !this.对象死亡)
							{
								if (this.网格距离(对象) <= PetObject2.仇恨范围 && PetObject2.主动攻击(对象) && !对象.检查状态(游戏对象状态.隐身状态 | 游戏对象状态.潜行状态))
								{
									PetObject2.HateObject.添加仇恨(对象, default(DateTime), 0);
									return;
								}
								HateObject.仇恨详情 仇恨详情3;
								if (this.网格距离(对象) > PetObject2.仇恨范围 && PetObject2.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情3) && 仇恨详情3.仇恨时间 < MainProcess.当前时间)
								{
									PetObject2.HateObject.移除仇恨(对象);
									return;
								}
							}
							else
							{
								MonsterObject MonsterObject2 = this as MonsterObject;
								if (MonsterObject2 != null && !this.对象死亡)
								{
									HateObject.仇恨详情 仇恨详情4;
									if (this.网格距离(对象) <= MonsterObject2.仇恨范围 && MonsterObject2.主动攻击(对象) && (MonsterObject2.可见隐身目标 || !对象.检查状态(游戏对象状态.隐身状态 | 游戏对象状态.潜行状态)))
									{
										MonsterObject2.HateObject.添加仇恨(对象, default(DateTime), 0);
									}
									else if (this.网格距离(对象) > MonsterObject2.仇恨范围 && MonsterObject2.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情4) && 仇恨详情4.仇恨时间 < MainProcess.当前时间)
									{
										MonsterObject2.HateObject.移除仇恨(对象);
									}
									if (this.重要邻居.Count != 0)
									{
										MonsterObject2.怪物激活处理();
										return;
									}
								}
								else
								{
									GuardInstance GuardInstance = this as GuardInstance;
									if (GuardInstance != null && !this.对象死亡)
									{
										if (GuardInstance.主动攻击(对象) && this.网格距离(对象) <= GuardInstance.仇恨范围)
										{
											GuardInstance.HateObject.添加仇恨(对象, default(DateTime), 0);
										}
										else if (this.网格距离(对象) > GuardInstance.仇恨范围)
										{
											GuardInstance.HateObject.移除仇恨(对象);
										}
										if (this.重要邻居.Count != 0)
										{
											GuardInstance.守卫激活处理();
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x0003EDC8 File Offset: 0x0003CFC8
		public void 对象消失时处理(MapObject 对象)
		{
			if (this.邻居列表.Remove(对象))
			{
				this.潜行邻居.Remove(对象);
				this.重要邻居.Remove(对象);
				if (!(this is ItemObject))
				{
					PlayerObject PlayerObject = this as PlayerObject;
					if (PlayerObject != null)
					{
						PlayerObject.网络连接.发送封包(new ObjectOutOfViewPacket
						{
							对象编号 = 对象.地图编号
						});
						return;
					}
					PetObject PetObject = this as PetObject;
					if (PetObject != null)
					{
						PetObject.HateObject.移除仇恨(对象);
						return;
					}
					MonsterObject MonsterObject = this as MonsterObject;
					if (MonsterObject != null)
					{
						if (!this.对象死亡)
						{
							MonsterObject.HateObject.移除仇恨(对象);
							if (MonsterObject.重要邻居.Count == 0)
							{
								MonsterObject.怪物沉睡处理();
								return;
							}
						}
					}
					else
					{
						GuardInstance GuardInstance = this as GuardInstance;
						if (GuardInstance != null && !this.对象死亡)
						{
							GuardInstance.HateObject.移除仇恨(对象);
							if (GuardInstance.重要邻居.Count == 0)
							{
								GuardInstance.守卫沉睡处理();
							}
						}
					}
				}
			}
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x0003EEB0 File Offset: 0x0003D0B0
		public void 对象死亡时处理(MapObject 对象)
		{
			MonsterObject MonsterObject = this as MonsterObject;
			if (MonsterObject != null)
			{
				MonsterObject.HateObject.移除仇恨(对象);
				return;
			}
			PetObject PetObject = this as PetObject;
			if (PetObject != null)
			{
				PetObject.HateObject.移除仇恨(对象);
				return;
			}
			GuardInstance GuardInstance = this as GuardInstance;
			if (GuardInstance != null)
			{
				GuardInstance.HateObject.移除仇恨(对象);
				return;
			}
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x0003EF08 File Offset: 0x0003D108
		public void 对象隐身时处理(MapObject 对象)
		{
			PetObject PetObject = this as PetObject;
			if (PetObject != null && PetObject.HateObject.仇恨列表.ContainsKey(对象))
			{
				PetObject.HateObject.移除仇恨(对象);
			}
			MonsterObject MonsterObject = this as MonsterObject;
			if (MonsterObject != null && MonsterObject.HateObject.仇恨列表.ContainsKey(对象) && !MonsterObject.可见隐身目标)
			{
				MonsterObject.HateObject.移除仇恨(对象);
			}
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x0003EF74 File Offset: 0x0003D174
		public void 对象潜行时处理(MapObject 对象)
		{
			PetObject PetObject = this as PetObject;
			if (PetObject != null)
			{
				if (PetObject.HateObject.仇恨列表.ContainsKey(对象))
				{
					PetObject.HateObject.移除仇恨(对象);
				}
				this.潜行邻居.Add(对象);
			}
			MonsterObject MonsterObject = this as MonsterObject;
			if (MonsterObject != null && !MonsterObject.可见隐身目标)
			{
				if (MonsterObject.HateObject.仇恨列表.ContainsKey(对象))
				{
					MonsterObject.HateObject.移除仇恨(对象);
				}
				this.潜行邻居.Add(对象);
			}
			PlayerObject PlayerObject = this as PlayerObject;
			if (PlayerObject != null && (this.对象关系(对象) == 游戏对象关系.敌对 || 对象.对象关系(this) == 游戏对象关系.敌对))
			{
				this.潜行邻居.Add(对象);
				PlayerObject.网络连接.发送封包(new ObjectOutOfViewPacket
				{
					对象编号 = 对象.地图编号
				});
			}
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x0003F040 File Offset: 0x0003D240
		public void 对象显隐时处理(MapObject 对象)
		{
			PetObject PetObject = this as PetObject;
			if (PetObject != null)
			{
				HateObject.仇恨详情 仇恨详情;
				if (this.网格距离(对象) <= PetObject.仇恨范围 && PetObject.主动攻击(对象) && !对象.检查状态(游戏对象状态.隐身状态 | 游戏对象状态.潜行状态))
				{
					PetObject.HateObject.添加仇恨(对象, default(DateTime), 0);
				}
				else if (this.网格距离(对象) > PetObject.仇恨范围 && PetObject.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情) && 仇恨详情.仇恨时间 < MainProcess.当前时间)
				{
					PetObject.HateObject.移除仇恨(对象);
				}
			}
			MonsterObject MonsterObject = this as MonsterObject;
			if (MonsterObject != null)
			{
				if (this.网格距离(对象) <= MonsterObject.仇恨范围 && MonsterObject.主动攻击(对象) && (MonsterObject.可见隐身目标 || !对象.检查状态(游戏对象状态.隐身状态 | 游戏对象状态.潜行状态)))
				{
					MonsterObject.HateObject.添加仇恨(对象, default(DateTime), 0);
					return;
				}
				HateObject.仇恨详情 仇恨详情2;
				if (this.网格距离(对象) > MonsterObject.仇恨范围 && MonsterObject.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情2) && 仇恨详情2.仇恨时间 < MainProcess.当前时间)
				{
					MonsterObject.HateObject.移除仇恨(对象);
				}
			}
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x000067A9 File Offset: 0x000049A9
		public void 对象显行时处理(MapObject 对象)
		{
			if (this.潜行邻居.Contains(对象))
			{
				this.对象出现时处理(对象);
			}
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x0003F170 File Offset: 0x0003D370
		public byte[] 对象Buff详述()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream(34))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write((byte)this.Buff列表.Count);
					foreach (KeyValuePair<ushort, BuffData> keyValuePair in this.Buff列表)
					{
						binaryWriter.Write(keyValuePair.Value.Buff编号.V);
						binaryWriter.Write((int)keyValuePair.Value.Buff编号.V);
						binaryWriter.Write(keyValuePair.Value.当前层数.V);
						binaryWriter.Write((int)keyValuePair.Value.剩余时间.V.TotalMilliseconds);
						binaryWriter.Write((int)keyValuePair.Value.持续时间.V.TotalMilliseconds);
					}
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x0003F2A0 File Offset: 0x0003D4A0
		public byte[] 对象Buff简述()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream(34))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(this.地图编号);
					int num = 0;
					foreach (KeyValuePair<ushort, BuffData> keyValuePair in this.Buff列表)
					{
						binaryWriter.Write(keyValuePair.Value.Buff编号.V);
						binaryWriter.Write((int)keyValuePair.Value.Buff编号.V);
						if (++num >= 5)
						{
							break;
						}
					}
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		// Token: 0x04000CAC RID: 3244
		public bool 次要对象;

		// Token: 0x04000CAD RID: 3245
		public bool 激活对象;

		// Token: 0x04000CAE RID: 3246
		public HashSet<MapObject> 重要邻居;

		// Token: 0x04000CAF RID: 3247
		public HashSet<MapObject> 潜行邻居;

		// Token: 0x04000CB0 RID: 3248
		public HashSet<MapObject> 邻居列表;

		// Token: 0x04000CB1 RID: 3249
		public HashSet<技能实例> 技能任务;

		// Token: 0x04000CB2 RID: 3250
		public HashSet<TrapObject> 陷阱列表;

		// Token: 0x04000CCE RID: 3278
		public Dictionary<object, Dictionary<GameObjectProperties, int>> 属性加成;
	}
}
