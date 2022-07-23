using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	
	public class GameItems
	{
		public static Dictionary<int, GameItems> DataSheet;
		public static Dictionary<string, GameItems> DateSheetByName;

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

		public static GameItems GetItem(int id)
		{
            if (!DataSheet.TryGetValue(id, out GameItems result))
            {
                return null;
            }
            return result;
		}

		
		public static GameItems GetItem(string name)
		{
            if (!DateSheetByName.TryGetValue(name, out GameItems result))
				return null;
			return result;
		}

		
		public static void LoadData()
		{
			DataSheet = new Dictionary<int, GameItems>();
			DateSheetByName = new Dictionary<string, GameItems>();

			string text = CustomClass.GameDataPath + "\\System\\Items\\Common\\";
			if (Directory.Exists(text))
			{
				object[] array = Serializer.Deserialize(text, typeof(GameItems));
				for (int i = 0; i < array.Length; i++)
				{
					GameItems gameItem = array[i] as GameItems;
					DataSheet.Add(gameItem.物品编号, gameItem);
					DateSheetByName.Add(gameItem.物品名字, gameItem);
				}
			}

			text = CustomClass.GameDataPath + "\\System\\Items\\Equipment\\";
			if (Directory.Exists(text))
			{
				object[] array = Serializer.Deserialize(text, typeof(EquipmentItem));
				for (int i = 0; i < array.Length; i++)
				{
					EquipmentItem gameItem = array[i] as EquipmentItem;
					DataSheet.Add(gameItem.物品编号, gameItem);
					DateSheetByName.Add(gameItem.物品名字, gameItem);
				}
			}
		}
	}
}
