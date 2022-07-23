using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameServer.Templates
{
	
	public sealed class 装备属性
	{
		
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

		
		public static void LoadData()
		{
			装备属性.DataSheet = new Dictionary<byte, 装备属性>();
			string text = CustomClass.GameDataPath + "\\System\\Items\\EquipmentStats\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in Serializer.Deserialize(text, typeof(装备属性)))
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

		
		public 装备属性()
		{
			
			
		}

		
		public static Dictionary<byte, 装备属性> DataSheet;

		
		public static Dictionary<byte, 随机属性[]> 概率表;

		
		public ItemUsageType 装备部位;

		
		public float 极品概率;

		
		public int 单条概率;

		
		public int 两条概率;

		
		public 装备属性.属性详情[] 属性列表;

		
		public class 属性详情
		{
			
			public 属性详情()
			{
				
				
			}

			
			public int 属性编号;

			
			public int 属性概率;
		}
	}
}
