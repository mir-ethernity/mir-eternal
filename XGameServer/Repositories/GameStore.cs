using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GameServer.Data;

namespace GameServer.Templates
{
    public sealed class GameStore
    {
        public static byte[] StoreBuffer;
        public static int StoreVersion;
        public static int StoreItemsCounts;
        public static int ItemsSort;
        public static Dictionary<int, GameStore> DataSheet;

        public int StoreId;
        public string Name;
        public ItemsForSale RecyclingType;
        public List<GameStoreItem> Products;
        public SortedSet<ItemData> AvailableItems = new SortedSet<ItemData>(new 回购排序());

        public static void LoadData()
        {
            DataSheet = new Dictionary<int, GameStore>();
            var text = Path.Combine(Config.GameDataPath, "System", "Items", "GameStore");
            if (Directory.Exists(text))
            {
                foreach (object obj in Serializer.Deserialize(text, typeof(GameStore)))
                {
                    DataSheet.Add(((GameStore)obj).StoreId, (GameStore)obj);
                }
            }

            using (MemoryStream memoryStream = new MemoryStream())
            using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
            {
                var items = (from X in GameStore.DataSheet.Values.ToList()
                             orderby X.StoreId
                             select X).ToList();

                foreach (GameStore store in items)
                {
                    foreach (GameStoreItem product in store.Products)
                    {
                        var name = Encoding.UTF8.GetBytes(store.Name);

                        binaryWriter.Write(store.StoreId);
                        binaryWriter.Write(name);
                        binaryWriter.Write(new byte[64 - name.Length]);
                        binaryWriter.Write(product.Id);
                        binaryWriter.Write(product.Units);
                        binaryWriter.Write(product.CurrencyType);
                        binaryWriter.Write(product.Price);
                        binaryWriter.Write(-1);
                        binaryWriter.Write(0);
                        binaryWriter.Write(-1);
                        binaryWriter.Write(0);
                        binaryWriter.Write(0);
                        binaryWriter.Write(0);
                        binaryWriter.Write((int)store.RecyclingType);
                        binaryWriter.Write(0);
                        binaryWriter.Write(0);
                        binaryWriter.Write((ushort)0);
                        binaryWriter.Write(-1);
                        binaryWriter.Write(-1);
                        StoreItemsCounts++;
                    }
                }

                var buffer = memoryStream.ToArray();

                StoreBuffer = Serializer.Decompress(buffer);

                StoreVersion = 0;

                foreach (byte b in GameStore.StoreBuffer)
                    StoreVersion += (int)b;
            }
        }

        public bool BuyItem(ItemData item)
        {
            return this.AvailableItems.Remove(item);
        }

        public void SellItem(ItemData item)
        {
            item.PurchaseId = ++ItemsSort;
            if (this.AvailableItems.Add(item) && this.AvailableItems.Count > 50)
            {
                ItemData ItemData = this.AvailableItems.Last<ItemData>();
                this.AvailableItems.Remove(ItemData);
                ItemData.Delete();
            }
        }
    }
}
