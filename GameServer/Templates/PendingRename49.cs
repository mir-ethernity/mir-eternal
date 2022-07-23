using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameServer.Templates
{
	// Token: 0x020002CB RID: 715
	public sealed class 装备属性
	{
		// Token: 0x060006F2 RID: 1778 RVA: 0x00035DB4 File Offset: 0x00033FB4
		public static List<随机属性> 生成属性(ItemUsageType 部位, bool 重铸装备 = false)
		{
			装备属性 装备属性;
			随机属性[] array;
			if (装备属性.DataSheet.TryGetValue((byte)部位, out 装备属性) && 装备属性.概率表.TryGetValue((byte)部位, out array) && array.Length != 0 && (重铸装备 || ComputingClass.计算概率(装备属性.极品概率)))
			{
				int num = MainProcess.RandomNumber.Next(100);
				Dictionary<GameObjectProperties, 随机属性> dictionary = new Dictionary<GameObjectProperties, 随机属性>();
				int num2 = (num < 装备属性.单条概率) ? 1 : ((num < 装备属性.两条概率) ? 2 : 3);
				for (int i = 0; i < num2; i++)
				{
					随机属性 随机属性 = array[MainProcess.RandomNumber.Next(array.Length)];
					if (!dictionary.ContainsKey(随机属性.对应属性))
					{
						dictionary[随机属性.对应属性] = 随机属性;
					}
				}
				return dictionary.Values.ToList<随机属性>();
			}
			return new List<随机属性>();
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x00035E80 File Offset: 0x00034080
		public static void LoadData()
		{
			装备属性.DataSheet = new Dictionary<byte, 装备属性>();
			string text = CustomClass.GameData目录 + "\\System\\Items\\EquipmentStats\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in 序列化类.反序列化(text, typeof(装备属性)))
				{
					装备属性.DataSheet.Add((byte)((装备属性)obj).装备部位, (装备属性)obj);
				}
			}
			装备属性.概率表 = new Dictionary<byte, 随机属性[]>();
			foreach (KeyValuePair<byte, 装备属性> keyValuePair in 装备属性.DataSheet)
			{
				List<随机属性> list = new List<随机属性>();
				foreach (装备属性.属性详情 属性详情 in keyValuePair.Value.属性列表)
				{
					随机属性 item;
					if (随机属性.DataSheet.TryGetValue(属性详情.属性编号, out item))
					{
						for (int j = 0; j < 属性详情.属性概率; j++)
						{
							list.Add(item);
						}
					}
				}
				装备属性.概率表[keyValuePair.Key] = list.ToArray();
			}
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x000027D8 File Offset: 0x000009D8
		public 装备属性()
		{
			
			
		}

		// Token: 0x04000C30 RID: 3120
		public static Dictionary<byte, 装备属性> DataSheet;

		// Token: 0x04000C31 RID: 3121
		public static Dictionary<byte, 随机属性[]> 概率表;

		// Token: 0x04000C32 RID: 3122
		public ItemUsageType 装备部位;

		// Token: 0x04000C33 RID: 3123
		public float 极品概率;

		// Token: 0x04000C34 RID: 3124
		public int 单条概率;

		// Token: 0x04000C35 RID: 3125
		public int 两条概率;

		// Token: 0x04000C36 RID: 3126
		public 装备属性.属性详情[] 属性列表;

		// Token: 0x020002CC RID: 716
		public class 属性详情
		{
			// Token: 0x060006F5 RID: 1781 RVA: 0x000027D8 File Offset: 0x000009D8
			public 属性详情()
			{
				
				
			}

			// Token: 0x04000C37 RID: 3127
			public int 属性编号;

			// Token: 0x04000C38 RID: 3128
			public int 属性概率;
		}
	}
}
