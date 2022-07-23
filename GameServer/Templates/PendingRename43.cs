using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	
	public class 游戏物品
	{
		
		public static 游戏物品 获取数据(int 索引)
		{
			游戏物品 result;
			if (!游戏物品.DataSheet.TryGetValue(索引, out result))
			{
				return null;
			}
			return result;
		}

		
		public static 游戏物品 获取数据(string 名字)
		{
			游戏物品 result;
			if (!游戏物品.检索表.TryGetValue(名字, out result))
			{
				return null;
			}
			return result;
		}

		
		public static void LoadData()
		{
			游戏物品.DataSheet = new Dictionary<int, 游戏物品>();
			游戏物品.检索表 = new Dictionary<string, 游戏物品>();
			string text = CustomClass.GameData目录 + "\\System\\Items\\CommonItems\\";
			if (Directory.Exists(text))
			{
				object[] array = Serializer.Deserialize(text, typeof(游戏物品));
				for (int i = 0; i < array.Length; i++)
				{
					游戏物品 游戏物品 = array[i] as 游戏物品;
					游戏物品.DataSheet.Add(游戏物品.物品编号, 游戏物品);
					游戏物品.检索表.Add(游戏物品.物品名字, 游戏物品);
				}
			}
			text = CustomClass.GameData目录 + "\\System\\Items\\EquipmentItems\\";
			if (Directory.Exists(text))
			{
				object[] array = Serializer.Deserialize(text, typeof(游戏装备));
				for (int i = 0; i < array.Length; i++)
				{
					游戏装备 游戏装备 = array[i] as 游戏装备;
					游戏物品.DataSheet.Add(游戏装备.物品编号, 游戏装备);
					游戏物品.检索表.Add(游戏装备.物品名字, 游戏装备);
				}
			}
		}

		
		public 游戏物品()
		{
			
			
		}

		
		public static Dictionary<int, 游戏物品> DataSheet;

		
		public static Dictionary<string, 游戏物品> 检索表;

		
		public string 物品名字;

		
		public int 物品编号;

		
		public int 物品持久;

		
		public int 物品重量;

		
		public int 物品等级;

		
		public int 需要等级;

		
		public int 冷却时间;

		
		public byte 物品分组;

		
		public int 分组冷却;

		
		public int 出售价格;

		
		public ushort 附加技能;

		
		public bool 是否绑定;

		
		public bool 能否分解;

		
		public bool 能否掉落;

		
		public bool 能否出售;

		
		public bool 贵重物品;

		
		public bool 资源物品;

		
		public ItemUsageType 物品分类;

		
		public GameObjectProfession 需要职业;

		
		public GameObjectGender 需要性别;

		
		public PersistentItemType 持久类型;

		
		public ItemsForSale 商店类型;
	}
}
