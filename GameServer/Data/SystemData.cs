using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Data
{
	
	public class SystemData : GameData
	{
		
		public SystemData()
		{
			
			
		}

		
		public SystemData(int 索引)
		{
			
			
			this.数据索引.V = 索引;
			GameDataGateway.Data型表[typeof(SystemData)].AddData(this, false);
		}

		
		// (get) Token: 0x06000460 RID: 1120 RVA: 0x0000456C File Offset: 0x0000276C
		public static SystemData 数据
		{
			get
			{
				return GameDataGateway.Data型表[typeof(SystemData)].DataSheet[1] as SystemData;
			}
		}

		
		public void 更新战力(CharacterData 角色)
		{
			SystemData.更新榜单(this.个人战力排名, 6, 角色, SystemData.战力计算器);
			switch (角色.角色职业.V)
			{
			case GameObjectRace.战士:
				SystemData.更新榜单(this.战士战力排名, 7, 角色, SystemData.战力计算器);
				return;
			case GameObjectRace.法师:
				SystemData.更新榜单(this.法师战力排名, 8, 角色, SystemData.战力计算器);
				return;
			case GameObjectRace.刺客:
				SystemData.更新榜单(this.刺客战力排名, 10, 角色, SystemData.战力计算器);
				return;
			case GameObjectRace.弓手:
				SystemData.更新榜单(this.弓手战力排名, 11, 角色, SystemData.战力计算器);
				return;
			case GameObjectRace.道士:
				SystemData.更新榜单(this.道士战力排名, 9, 角色, SystemData.战力计算器);
				return;
			case GameObjectRace.龙枪:
				SystemData.更新榜单(this.龙枪战力排名, 37, 角色, SystemData.战力计算器);
				return;
			default:
				return;
			}
		}

		
		public void 更新等级(CharacterData 角色)
		{
			SystemData.更新榜单(this.个人等级排名, 0, 角色, SystemData.等级计算器);
			switch (角色.角色职业.V)
			{
			case GameObjectRace.战士:
				SystemData.更新榜单(this.战士等级排名, 1, 角色, SystemData.等级计算器);
				return;
			case GameObjectRace.法师:
				SystemData.更新榜单(this.法师等级排名, 2, 角色, SystemData.等级计算器);
				return;
			case GameObjectRace.刺客:
				SystemData.更新榜单(this.刺客等级排名, 4, 角色, SystemData.等级计算器);
				return;
			case GameObjectRace.弓手:
				SystemData.更新榜单(this.弓手等级排名, 5, 角色, SystemData.等级计算器);
				return;
			case GameObjectRace.道士:
				SystemData.更新榜单(this.道士等级排名, 3, 角色, SystemData.等级计算器);
				return;
			case GameObjectRace.龙枪:
				SystemData.更新榜单(this.龙枪等级排名, 36, 角色, SystemData.等级计算器);
				return;
			default:
				return;
			}
		}

		
		public void 更新声望(CharacterData 角色)
		{
			SystemData.更新榜单(this.个人声望排名, 14, 角色, SystemData.声望计算器);
		}

		
		public void 更新PK值(CharacterData 角色)
		{
			SystemData.更新榜单(this.个人PK值排名, 15, 角色, SystemData.PK值计算器);
		}

		
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

		
		public void 解封网络(string 地址)
		{
			if (this.网络封禁.Remove(地址))
			{
				MainForm.移除封禁数据(地址);
			}
		}

		
		public void 解封网卡(string 地址)
		{
			if (this.网卡封禁.Remove(地址))
			{
				MainForm.移除封禁数据(地址);
			}
		}

		
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
						binaryWriter.Write(ComputingClass.TimeShift(keyValuePair.Key.AddDays(-1.0)));
					}
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		
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

		
		static SystemData()
		{
			
			SystemData.战力计算器 = new SystemData.战力比较器();
			SystemData.等级计算器 = new SystemData.等级比较器();
			SystemData.声望计算器 = new SystemData.声望比较器();
			SystemData.PK值计算器 = new SystemData.PK值比较器();
			SystemData.行会计算器 = new SystemData.行会比较器();
		}

		
		public readonly MonitorDictionary<string, DateTime> 网络封禁;

		
		public readonly MonitorDictionary<string, DateTime> 网卡封禁;

		
		public readonly DataMonitor<DateTime> 占领时间;

		
		public readonly DataMonitor<GuildData> 占领行会;

		
		public readonly MonitorDictionary<DateTime, GuildData> 申请行会;

		
		public readonly ListMonitor<CharacterData> 个人战力排名;

		
		public readonly ListMonitor<CharacterData> 个人等级排名;

		
		public readonly ListMonitor<CharacterData> 个人声望排名;

		
		public readonly ListMonitor<CharacterData> 个人PK值排名;

		
		public readonly ListMonitor<CharacterData> 战士战力排名;

		
		public readonly ListMonitor<CharacterData> 法师战力排名;

		
		public readonly ListMonitor<CharacterData> 道士战力排名;

		
		public readonly ListMonitor<CharacterData> 刺客战力排名;

		
		public readonly ListMonitor<CharacterData> 弓手战力排名;

		
		public readonly ListMonitor<CharacterData> 龙枪战力排名;

		
		public readonly ListMonitor<CharacterData> 战士等级排名;

		
		public readonly ListMonitor<CharacterData> 法师等级排名;

		
		public readonly ListMonitor<CharacterData> 道士等级排名;

		
		public readonly ListMonitor<CharacterData> 刺客等级排名;

		
		public readonly ListMonitor<CharacterData> 弓手等级排名;

		
		public readonly ListMonitor<CharacterData> 龙枪等级排名;

		
		public readonly ListMonitor<GuildData> 行会人数排名;

		
		private static readonly SystemData.战力比较器 战力计算器;

		
		private static readonly SystemData.等级比较器 等级计算器;

		
		private static readonly SystemData.声望比较器 声望计算器;

		
		private static readonly SystemData.PK值比较器 PK值计算器;

		
		private static readonly SystemData.行会比较器 行会计算器;

		
		private sealed class 行会比较器 : IComparer<GuildData>
		{
			
			public int Compare(GuildData x, GuildData y)
			{
				return x.行会成员.Count - y.行会成员.Count;
			}

			
			public 行会比较器()
			{
				
				
			}
		}

		
		private sealed class 等级比较器 : IComparer<CharacterData>
		{
			
			public int Compare(CharacterData x, CharacterData y)
			{
				if (x.角色等级 == y.角色等级)
				{
					return x.角色经验 - y.角色经验;
				}
				return (int)(x.角色等级 - y.角色等级);
			}

			
			public 等级比较器()
			{
				
				
			}
		}

		
		private sealed class 战力比较器 : IComparer<CharacterData>
		{
			
			public int Compare(CharacterData x, CharacterData y)
			{
				return x.角色战力 - y.角色战力;
			}

			
			public 战力比较器()
			{
				
				
			}
		}

		
		private sealed class 声望比较器 : IComparer<CharacterData>
		{
			
			public int Compare(CharacterData x, CharacterData y)
			{
				return x.师门声望 - y.师门声望;
			}

			
			public 声望比较器()
			{
				
				
			}
		}

		
		private sealed class PK值比较器 : IComparer<CharacterData>
		{
			
			public int Compare(CharacterData x, CharacterData y)
			{
				return x.角色PK值 - y.角色PK值;
			}

			
			public PK值比较器()
			{
				
				
			}
		}
	}
}
