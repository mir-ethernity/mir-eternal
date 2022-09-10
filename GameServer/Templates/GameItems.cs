using GameServer.Enums;
using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
    public class GameItems
    {
        public static Dictionary<int, GameItems> DataSheet;
        public static Dictionary<string, GameItems> DataSheetByName;

        public string Name;
        public int Id;
        public int MaxDura;
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
        public int? UnpackItemId;
        public List<GameItemTreasure> TreasureItems = new List<GameItemTreasure>();

        public ItemType Type;
        public GameObjectRace NeedRace;
        public GameObjectGender NeedGender;
        public PersistentItemType PersistType;
        public ItemsForSale StoreType;

        public IDictionary<ItemProperty, int> Props = new Dictionary<ItemProperty, int>();

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
            if (!DataSheetByName.TryGetValue(name, out GameItems result))
                return null;
            return result;
        }


        public static void LoadData()
        {
            DataSheet = new Dictionary<int, GameItems>();
            DataSheetByName = new Dictionary<string, GameItems>();

            string text = Config.GameDataPath + "\\System\\Items\\Common\\";
            if (Directory.Exists(text))
            {
                var array = Serializer.Deserialize<GameItems>(text);
                for (int i = 0; i < array.Length; i++)
                {
                    GameItems gameItem = array[i] as GameItems;
                    DataSheet.Add(gameItem.Id, gameItem);
                    DataSheetByName.Add(gameItem.Name, gameItem);
                }
            }

            text = Config.GameDataPath + "\\System\\Items\\Equipment\\";
            if (Directory.Exists(text))
            {
                var array = Serializer.Deserialize<EquipmentItem>(text);
                for (int i = 0; i < array.Length; i++)
                {
                    EquipmentItem gameItem = array[i] as EquipmentItem;
                    DataSheet.Add(gameItem.Id, gameItem);
                    DataSheetByName.Add(gameItem.Name, gameItem);
                }
            }
        }
    }
}
