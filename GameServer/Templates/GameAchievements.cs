using Models.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Templates
{
    public class GameAchievementCondition
    {
        public string Desc { get; set; }
        public string Type { get; set; }
        public Dictionary<string, object> Props { get; set; }
    }

    public class GameAchievementReward
    {
        public QuestRewardType Type { get; set; }
        public int Id { get; set; }
    }

    public class GameAchievements
    {
        public static Dictionary<ushort, GameAchievements> DataSheet;

        public ushort Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int BaseClass { get; set; }
        public int SubClass { get; set; }
        public QuestResetType ResetType { get; set; }
        public int AchievementPoints { get; set; }
        public List<int> PreAchivements { get; set; } = new List<int>();
        public List<GameAchievementCondition> Conditions { get; set; } = new List<GameAchievementCondition>();
        public List<GameAchievementReward> Rewards { get; set; } = new List<GameAchievementReward>();


        public static void LoadData()
        {
            string text = Config.GameDataPath + "\\System\\Achievements\\";

            if (Directory.Exists(text))
                DataSheet = Serializer.Deserialize<GameAchievements>(text).ToDictionary(x => x.Id);
            else
                DataSheet = new Dictionary<ushort, GameAchievements>();
        }
    }
}
