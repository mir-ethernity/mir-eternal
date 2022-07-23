using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	
	public class GameItems
	{
		public static Dictionary<int, GameItems> DataSheet;
		public static Dictionary<string, GameItems> DateSheetByName;

		public string Name;
		public int Id;
		public int ItemLast;
		public int Weight;
		public int Level;
		public int NeedLevel;
		public int Cooldown;
		public byte Group;
		public int GroupCooling;
		public int SalePrice;
		public ushort AdditionalSkill;
		public bool IsBound;
		public bool IsStackable;
		public bool CanDrop;
		public bool CanSold;
		public bool ValuableObjects;
		public bool Resource;
		public ItemUsageType UsageType;
		public GameObjectProfession NeedRace;
		public GameObjectGender NeedGender;
		public PersistentItemType PersistType;
		public ItemsForSale StoreType;

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
					DataSheet.Add(gameItem.Id, gameItem);
					DateSheetByName.Add(gameItem.Name, gameItem);
				}
			}

			text = CustomClass.GameDataPath + "\\System\\Items\\Equipment\\";
			if (Directory.Exists(text))
			{
				object[] array = Serializer.Deserialize(text, typeof(EquipmentItem));
				for (int i = 0; i < array.Length; i++)
				{
					EquipmentItem gameItem = array[i] as EquipmentItem;
					DataSheet.Add(gameItem.Id, gameItem);
					DateSheetByName.Add(gameItem.Name, gameItem);
				}
			}
		}
	}
}
