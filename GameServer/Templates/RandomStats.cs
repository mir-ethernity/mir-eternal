using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
    public sealed class RandomStats
    {
        public static Dictionary<int, RandomStats> DataSheet;

        public GameObjectStats Stat;
        public int Value;
        public int StatId;
        public int CombatBonus;
        public string StatDescription;

        public static void LoadData()
        {
            DataSheet = new Dictionary<int, RandomStats>();
            var text = Config.GameDataPath + "\\System\\Items\\RandomStats\\";

            if (Directory.Exists(text))
            {
                foreach (var obj in Serializer.Deserialize<RandomStats>(text))
                    DataSheet.Add(obj.StatId, obj);

            }
        }
    }
}
