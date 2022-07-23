using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameServer.Templates
{
    public sealed partial class EquipmentStats
    {
        public static Dictionary<byte, EquipmentStats> DataSheet;
        public static Dictionary<byte, RandomStats[]> 概率表;

        public ItemType ItemType;
        public float ExtremeProbability;
        public int SingleProbability;
        public int TwoProbability;
        public StatsDetail[] Stats;

        public static List<RandomStats> GenerateStats(ItemType Type, bool reforgedEquipment = false)
        {
            EquipmentStats stats;
            if (DataSheet.TryGetValue((byte)Type, out stats) && 概率表.TryGetValue((byte)Type, out RandomStats[] array) && array.Length != 0 && (reforgedEquipment || ComputingClass.计算概率(stats.ExtremeProbability)))
            {
                int num = MainProcess.RandomNumber.Next(100);
                Dictionary<GameObjectStats, RandomStats> dictionary = new Dictionary<GameObjectStats, RandomStats>();
                int num2 = (num < stats.SingleProbability) ? 1 : ((num < stats.TwoProbability) ? 2 : 3);
                for (int i = 0; i < num2; i++)
                {
                    RandomStats 随机属性 = array[MainProcess.RandomNumber.Next(array.Length)];
                    if (!dictionary.ContainsKey(随机属性.Stat))
                        dictionary[随机属性.Stat] = 随机属性;
                }
                return dictionary.Values.ToList();
            }
            return new List<RandomStats>();
        }

        public static void LoadData()
        {
            DataSheet = new Dictionary<byte, EquipmentStats>();
            var text = CustomClass.GameDataPath + "\\System\\Items\\EquipmentStats\\";

            if (Directory.Exists(text))
            {
                foreach (object obj in Serializer.Deserialize(text, typeof(EquipmentStats)))
                    DataSheet.Add((byte)((EquipmentStats)obj).ItemType, (EquipmentStats)obj);
            }

            概率表 = new Dictionary<byte, RandomStats[]>();

            foreach (KeyValuePair<byte, EquipmentStats> kvp in DataSheet)
            {
                var list = new List<RandomStats>();
                
                foreach (StatsDetail 属性详情 in kvp.Value.Stats)
                    if (RandomStats.DataSheet.TryGetValue(属性详情.StatId, out RandomStats item))
                        for (int j = 0; j < 属性详情.Probability; j++)
                            list.Add(item);

                概率表[kvp.Key] = list.ToArray();
            }
        }
    }
}
