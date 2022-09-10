using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameServer.Templates
{
    public sealed class Treasures
    {
        public static byte[] Buffer;
        public static int Checksum;
        public static int Count;
        public static Dictionary<int, Treasures> DataSheet;

        public int Id;
        public int Units;
        public byte Type;
        public byte Label;
        public byte AdditionalParam;
        public int OriginalPrice;
        public int CurrentPrice;
        public byte BuyBound;

        public static void LoadData()
        {
            DataSheet = new Dictionary<int, Treasures>();
            string text = Config.GameDataPath + "\\System\\Items\\Treasures\\";
            if (Directory.Exists(text))
            {
                foreach (var obj in Serializer.Deserialize<Treasures>(text))
                    DataSheet.Add(obj.Id, obj);
            }

            using var memoryStream = new MemoryStream();
            using var binaryWriter = new BinaryWriter(memoryStream);

            var sortedTreasures = (from X in DataSheet.Values.ToList()
                                   orderby X.Id
                                   select X).ToList();

            foreach (Treasures treasure in sortedTreasures)
            {
                binaryWriter.Write(treasure.Id);
                binaryWriter.Write(treasure.Units);
                binaryWriter.Write(treasure.Type);
                binaryWriter.Write(treasure.Label);
                binaryWriter.Write(treasure.AdditionalParam);
                binaryWriter.Write(treasure.OriginalPrice);
                binaryWriter.Write(treasure.CurrentPrice);
                binaryWriter.Write(new byte[48]);
            }

            Count = DataSheet.Count;
            Buffer = memoryStream.ToArray();
            Checksum = 0;

            foreach (byte b in Buffer)
                Checksum += b;
        }
    }
}
