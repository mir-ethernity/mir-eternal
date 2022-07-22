using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Data
{
	// Token: 0x02000254 RID: 596
	public class SystemData : GameData
	{
		// Token: 0x0600045E RID: 1118 RVA: 0x0000429F File Offset: 0x0000249F
		public SystemData()
		{
			
			
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00004538 File Offset: 0x00002738
		public SystemData(int 索引)
		{
			
			
			this.数据索引.V = 索引;
			GameDataGateway.Data型表[typeof(SystemData)].AddData(this, false);
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000460 RID: 1120 RVA: 0x0000456C File Offset: 0x0000276C
		public static SystemData 数据
		{
			get
			{
				return GameDataGateway.Data型表[typeof(SystemData)].DataSheet[1] as SystemData;
			}
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x0002111C File Offset: 0x0001F31C
		public void 更新战力(CharacterData 角色)
		{
			SystemData.更新榜单(this.个人战力排名, 6, 角色, SystemData.战力计算器);
			switch (角色.角色职业.V)
			{
			case GameObjectProfession.战士:
				SystemData.更新榜单(this.战士战力排名, 7, 角色, SystemData.战力计算器);
				return;
			case GameObjectProfession.法师:
				SystemData.更新榜单(this.法师战力排名, 8, 角色, SystemData.战力计算器);
				return;
			case GameObjectProfession.刺客:
				SystemData.更新榜单(this.刺客战力排名, 10, 角色, SystemData.战力计算器);
				return;
			case GameObjectProfession.弓手:
				SystemData.更新榜单(this.弓手战力排名, 11, 角色, SystemData.战力计算器);
				return;
			case GameObjectProfession.道士:
				SystemData.更新榜单(this.道士战力排名, 9, 角色, SystemData.战力计算器);
				return;
			case GameObjectProfession.龙枪:
				SystemData.更新榜单(this.龙枪战力排名, 37, 角色, SystemData.战力计算器);
				return;
			default:
				return;
			}
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x000211DC File Offset: 0x0001F3DC
		public void 更新等级(CharacterData 角色)
		{
			SystemData.更新榜单(this.个人等级排名, 0, 角色, SystemData.等级计算器);
			switch (角色.角色职业.V)
			{
			case GameObjectProfession.战士:
				SystemData.更新榜单(this.战士等级排名, 1, 角色, SystemData.等级计算器);
				return;
			case GameObjectProfession.法师:
				SystemData.更新榜单(this.法师等级排名, 2, 角色, SystemData.等级计算器);
				return;
			case GameObjectProfession.刺客:
				SystemData.更新榜单(this.刺客等级排名, 4, 角色, SystemData.等级计算器);
				return;
			case GameObjectProfession.弓手:
				SystemData.更新榜单(this.弓手等级排名, 5, 角色, SystemData.等级计算器);
				return;
			case GameObjectProfession.道士:
				SystemData.更新榜单(this.道士等级排名, 3, 角色, SystemData.等级计算器);
				return;
			case GameObjectProfession.龙枪:
				SystemData.更新榜单(this.龙枪等级排名, 36, 角色, SystemData.等级计算器);
				return;
			default:
				return;
			}
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x00004592 File Offset: 0x00002792
		public void 更新声望(CharacterData 角色)
		{
			SystemData.更新榜单(this.个人声望排名, 14, 角色, SystemData.声望计算器);
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x000045A7 File Offset: 0x000027A7
		public void 更新PK值(CharacterData 角色)
		{
			SystemData.更新榜单(this.个人PK值排名, 15, 角色, SystemData.PK值计算器);
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00021298 File Offset: 0x0001F498
		public void 更新行会(GuildData 行会)
		{
			int num = 行会.行会排名.V - 1;
			if (this.行会人数排名.Count < 100)
			{
				int num2;
				if (num >= 0)
				{
					this.行会人数排名.RemoveAt(num);
					num2 = SystemData.二分查找(this.行会人数排名, 行会, SystemData.行会计算器, 0, this.行会人数排名.Count);
					this.行会人数排名.Insert(num2, 行会);
					for (int i = Math.Min(num, num2); i <= Math.Max(num, num2); i++)
					{
						this.行会人数排名[i].行会排名.V = i + 1;
					}
					return;
				}
				num2 = SystemData.二分查找(this.行会人数排名, 行会, SystemData.行会计算器, 0, this.行会人数排名.Count);
				this.行会人数排名.Insert(num2, 行会);
				for (int j = num2; j < this.行会人数排名.Count; j++)
				{
					this.行会人数排名[j].行会排名.V = j + 1;
				}
				return;
			}
			else
			{
				if (num >= 0)
				{
					this.行会人数排名.RemoveAt(num);
					int num2 = SystemData.二分查找(this.行会人数排名, 行会, SystemData.行会计算器, 0, this.行会人数排名.Count);
					this.行会人数排名.Insert(num2, 行会);
					for (int k = Math.Min(num, num2); k <= Math.Max(num, num2); k++)
					{
						this.行会人数排名[k].行会排名.V = k + 1;
					}
					return;
				}
				if (SystemData.行会计算器.Compare(行会, this.行会人数排名.Last) > 0)
				{
					int num2 = SystemData.二分查找(this.行会人数排名, 行会, SystemData.行会计算器, 0, this.行会人数排名.Count);
					this.行会人数排名.Insert(num2, 行会);
					for (int l = num2; l < this.行会人数排名.Count; l++)
					{
						this.行会人数排名[l].行会排名.V = l + 1;
					}
					this.行会人数排名[100].行会排名.V = 0;
					this.行会人数排名.RemoveAt(100);
				}
				return;
			}
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x000214A0 File Offset: 0x0001F6A0
		public void BanIPCommand(string 地址, DateTime 时间)
		{
			if (this.网络封禁.ContainsKey(地址))
			{
				this.网络封禁[地址] = 时间;
				MainForm.更新封禁数据(地址, 时间, true);
				return;
			}
			this.网络封禁[地址] = 时间;
			MainForm.添加封禁数据(地址, 时间, true);
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x000214F0 File Offset: 0x0001F6F0
		public void BanNICCommand(string 地址, DateTime 时间)
		{
			if (this.网卡封禁.ContainsKey(地址))
			{
				this.网卡封禁[地址] = 时间;
				MainForm.更新封禁数据(地址, 时间, false);
				return;
			}
			this.网卡封禁[地址] = 时间;
			MainForm.添加封禁数据(地址, 时间, false);
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x000045BC File Offset: 0x000027BC
		public void 解封网络(string 地址)
		{
			if (this.网络封禁.Remove(地址))
			{
				MainForm.移除封禁数据(地址);
			}
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x000045D2 File Offset: 0x000027D2
		public void 解封网卡(string 地址)
		{
			if (this.网卡封禁.Remove(地址))
			{
				MainForm.移除封禁数据(地址);
			}
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00021540 File Offset: 0x0001F740
		public byte[] 沙城申请描述()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					foreach (KeyValuePair<DateTime, GuildData> keyValuePair in this.申请行会)
					{
						binaryWriter.Write(keyValuePair.Value.行会编号);
						binaryWriter.Write(ComputingClass.时间转换(keyValuePair.Key.AddDays(-1.0)));
					}
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00021604 File Offset: 0x0001F804
		public override void OnLoadCompleted()
		{
			foreach (KeyValuePair<string, DateTime> keyValuePair in this.网络封禁)
			{
				MainForm.添加封禁数据(keyValuePair.Key, keyValuePair.Value, true);
			}
			foreach (KeyValuePair<string, DateTime> keyValuePair2 in this.网卡封禁)
			{
				MainForm.添加封禁数据(keyValuePair2.Key, keyValuePair2.Value, false);
			}
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x000216B4 File Offset: 0x0001F8B4
		private static void 更新榜单(ListMonitor<CharacterData> 当前榜单, byte 当前类型, CharacterData 角色, IComparer<CharacterData> 比较方法)
		{
			int num = 角色.当前排名[当前类型] - 1;
			if (当前榜单.Count < 300)
			{
				int num2;
				if (num >= 0)
				{
					当前榜单.RemoveAt(num);
					num2 = SystemData.二分查找(当前榜单, 角色, 比较方法, 0, 当前榜单.Count);
					当前榜单.Insert(num2, 角色);
					for (int i = Math.Min(num, num2); i <= Math.Max(num, num2); i++)
					{
						当前榜单[i].历史排名[当前类型] = 当前榜单[i].当前排名[当前类型];
						当前榜单[i].当前排名[当前类型] = i + 1;
					}
					return;
				}
				num2 = SystemData.二分查找(当前榜单, 角色, SystemData.战力计算器, 0, 当前榜单.Count);
				当前榜单.Insert(num2, 角色);
				for (int j = num2; j < 当前榜单.Count; j++)
				{
					当前榜单[j].历史排名[当前类型] = 当前榜单[j].当前排名[当前类型];
					当前榜单[j].当前排名[当前类型] = j + 1;
				}
				return;
			}
			else
			{
				if (num >= 0)
				{
					当前榜单.RemoveAt(num);
					int num3 = SystemData.二分查找(当前榜单, 角色, 比较方法, 0, 当前榜单.Count);
					当前榜单.Insert(num3, 角色);
					for (int k = Math.Min(num, num3); k <= Math.Max(num, num3); k++)
					{
						当前榜单[k].历史排名[当前类型] = 当前榜单[k].当前排名[当前类型];
						当前榜单[k].当前排名[当前类型] = k + 1;
					}
					return;
				}
				if (比较方法.Compare(角色, 当前榜单.Last) > 0)
				{
					int num2 = SystemData.二分查找(当前榜单, 角色, SystemData.战力计算器, 0, 当前榜单.Count);
					当前榜单.Insert(num2, 角色);
					for (int l = num2; l < 当前榜单.Count; l++)
					{
						当前榜单[l].历史排名[当前类型] = 当前榜单[l].当前排名[当前类型];
						当前榜单[l].当前排名[当前类型] = l + 1;
					}
					当前榜单[300].当前排名.Remove(当前类型);
					当前榜单.RemoveAt(300);
				}
				return;
			}
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x000218E0 File Offset: 0x0001FAE0
		private static int 二分查找(ListMonitor<CharacterData> 列表, CharacterData 元素, IComparer<CharacterData> 比较器, int 起始位置, int 结束位置)
		{
			if (结束位置 < 0 || 列表.Count == 0)
			{
				return 0;
			}
			if (起始位置 >= 列表.Count)
			{
				return 列表.Count;
			}
			int num = (起始位置 + 结束位置) / 2;
			int num2 = 比较器.Compare(列表[num], 元素);
			if (num2 == 0)
			{
				return num;
			}
			if (num2 > 0)
			{
				if (num + 1 >= 列表.Count)
				{
					return 列表.Count;
				}
				if (比较器.Compare(列表[num + 1], 元素) <= 0)
				{
					return num + 1;
				}
				return SystemData.二分查找(列表, 元素, 比较器, num + 1, 结束位置);
			}
			else
			{
				if (num - 1 < 0)
				{
					return 0;
				}
				if (比较器.Compare(列表[num - 1], 元素) >= 0)
				{
					return num;
				}
				return SystemData.二分查找(列表, 元素, 比较器, 起始位置, num - 1);
			}
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00021994 File Offset: 0x0001FB94
		private static int 二分查找(ListMonitor<GuildData> 列表, GuildData 元素, IComparer<GuildData> 比较器, int 起始位置, int 结束位置)
		{
			if (结束位置 < 0)
			{
				return 0;
			}
			if (起始位置 >= 列表.Count)
			{
				return 列表.Count;
			}
			int num = (起始位置 + 结束位置) / 2;
			int num2 = 比较器.Compare(列表[num], 元素);
			if (num2 == 0)
			{
				return num;
			}
			if (num2 > 0)
			{
				if (num + 1 >= 列表.Count)
				{
					return 列表.Count;
				}
				if (比较器.Compare(列表[num + 1], 元素) <= 0)
				{
					return num + 1;
				}
				return SystemData.二分查找(列表, 元素, 比较器, num + 1, 结束位置);
			}
			else
			{
				if (num - 1 < 0)
				{
					return 0;
				}
				if (比较器.Compare(列表[num - 1], 元素) >= 0)
				{
					return num;
				}
				return SystemData.二分查找(列表, 元素, 比较器, 起始位置, num - 1);
			}
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x000045E8 File Offset: 0x000027E8
		static SystemData()
		{
			
			SystemData.战力计算器 = new SystemData.战力比较器();
			SystemData.等级计算器 = new SystemData.等级比较器();
			SystemData.声望计算器 = new SystemData.声望比较器();
			SystemData.PK值计算器 = new SystemData.PK值比较器();
			SystemData.行会计算器 = new SystemData.行会比较器();
		}

		// Token: 0x040007EA RID: 2026
		public readonly MonitorDictionary<string, DateTime> 网络封禁;

		// Token: 0x040007EB RID: 2027
		public readonly MonitorDictionary<string, DateTime> 网卡封禁;

		// Token: 0x040007EC RID: 2028
		public readonly DataMonitor<DateTime> 占领时间;

		// Token: 0x040007ED RID: 2029
		public readonly DataMonitor<GuildData> 占领行会;

		// Token: 0x040007EE RID: 2030
		public readonly MonitorDictionary<DateTime, GuildData> 申请行会;

		// Token: 0x040007EF RID: 2031
		public readonly ListMonitor<CharacterData> 个人战力排名;

		// Token: 0x040007F0 RID: 2032
		public readonly ListMonitor<CharacterData> 个人等级排名;

		// Token: 0x040007F1 RID: 2033
		public readonly ListMonitor<CharacterData> 个人声望排名;

		// Token: 0x040007F2 RID: 2034
		public readonly ListMonitor<CharacterData> 个人PK值排名;

		// Token: 0x040007F3 RID: 2035
		public readonly ListMonitor<CharacterData> 战士战力排名;

		// Token: 0x040007F4 RID: 2036
		public readonly ListMonitor<CharacterData> 法师战力排名;

		// Token: 0x040007F5 RID: 2037
		public readonly ListMonitor<CharacterData> 道士战力排名;

		// Token: 0x040007F6 RID: 2038
		public readonly ListMonitor<CharacterData> 刺客战力排名;

		// Token: 0x040007F7 RID: 2039
		public readonly ListMonitor<CharacterData> 弓手战力排名;

		// Token: 0x040007F8 RID: 2040
		public readonly ListMonitor<CharacterData> 龙枪战力排名;

		// Token: 0x040007F9 RID: 2041
		public readonly ListMonitor<CharacterData> 战士等级排名;

		// Token: 0x040007FA RID: 2042
		public readonly ListMonitor<CharacterData> 法师等级排名;

		// Token: 0x040007FB RID: 2043
		public readonly ListMonitor<CharacterData> 道士等级排名;

		// Token: 0x040007FC RID: 2044
		public readonly ListMonitor<CharacterData> 刺客等级排名;

		// Token: 0x040007FD RID: 2045
		public readonly ListMonitor<CharacterData> 弓手等级排名;

		// Token: 0x040007FE RID: 2046
		public readonly ListMonitor<CharacterData> 龙枪等级排名;

		// Token: 0x040007FF RID: 2047
		public readonly ListMonitor<GuildData> 行会人数排名;

		// Token: 0x04000800 RID: 2048
		private static readonly SystemData.战力比较器 战力计算器;

		// Token: 0x04000801 RID: 2049
		private static readonly SystemData.等级比较器 等级计算器;

		// Token: 0x04000802 RID: 2050
		private static readonly SystemData.声望比较器 声望计算器;

		// Token: 0x04000803 RID: 2051
		private static readonly SystemData.PK值比较器 PK值计算器;

		// Token: 0x04000804 RID: 2052
		private static readonly SystemData.行会比较器 行会计算器;

		// Token: 0x02000255 RID: 597
		private sealed class 行会比较器 : IComparer<GuildData>
		{
			// Token: 0x06000470 RID: 1136 RVA: 0x00004621 File Offset: 0x00002821
			public int Compare(GuildData x, GuildData y)
			{
				return x.行会成员.Count - y.行会成员.Count;
			}

			// Token: 0x06000471 RID: 1137 RVA: 0x000027D8 File Offset: 0x000009D8
			public 行会比较器()
			{
				
				
			}
		}

		// Token: 0x02000256 RID: 598
		private sealed class 等级比较器 : IComparer<CharacterData>
		{
			// Token: 0x06000472 RID: 1138 RVA: 0x0000463A File Offset: 0x0000283A
			public int Compare(CharacterData x, CharacterData y)
			{
				if (x.角色等级 == y.角色等级)
				{
					return x.角色经验 - y.角色经验;
				}
				return (int)(x.角色等级 - y.角色等级);
			}

			// Token: 0x06000473 RID: 1139 RVA: 0x000027D8 File Offset: 0x000009D8
			public 等级比较器()
			{
				
				
			}
		}

		// Token: 0x02000257 RID: 599
		private sealed class 战力比较器 : IComparer<CharacterData>
		{
			// Token: 0x06000474 RID: 1140 RVA: 0x00004665 File Offset: 0x00002865
			public int Compare(CharacterData x, CharacterData y)
			{
				return x.角色战力 - y.角色战力;
			}

			// Token: 0x06000475 RID: 1141 RVA: 0x000027D8 File Offset: 0x000009D8
			public 战力比较器()
			{
				
				
			}
		}

		// Token: 0x02000258 RID: 600
		private sealed class 声望比较器 : IComparer<CharacterData>
		{
			// Token: 0x06000476 RID: 1142 RVA: 0x00004674 File Offset: 0x00002874
			public int Compare(CharacterData x, CharacterData y)
			{
				return x.师门声望 - y.师门声望;
			}

			// Token: 0x06000477 RID: 1143 RVA: 0x000027D8 File Offset: 0x000009D8
			public 声望比较器()
			{
				
				
			}
		}

		// Token: 0x02000259 RID: 601
		private sealed class PK值比较器 : IComparer<CharacterData>
		{
			// Token: 0x06000478 RID: 1144 RVA: 0x00004683 File Offset: 0x00002883
			public int Compare(CharacterData x, CharacterData y)
			{
				return x.角色PK值 - y.角色PK值;
			}

			// Token: 0x06000479 RID: 1145 RVA: 0x000027D8 File Offset: 0x000009D8
			public PK值比较器()
			{
				
				
			}
		}
	}
}
