using Models;
using Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Templates
{
    public class GameQuests
    {
        public static IDictionary<int, GameQuests> DataSheet;
        public static GameQuests[] AvailableQuests;

        public int Id;
        public int Chapter;
        public int Stage;
        public string Name;
        public int Level;
        public QuestType Type;
        public QuestResetType Reset;
        public QuestRelationLimit RelationLimit;

        public int StartNPCMap;
        public int StartNPCID;
        public int FinishNPCID;
        public int AutoStartNextID;
        public int MaxCompleteCount;

        public int ResetTime;
        public bool CanAbandon;
        public bool CanShare;
        public bool CanPublish;
        public bool CanTeleport;

        public int TeleportCostId;
        public int TeleportCostValue;

        public List<GameQuestReward> Rewards = new List<GameQuestReward>();
        public List<GameQuestReward> SelectableRewards = new List<GameQuestReward>();
        public List<GameQuestMission> Missions = new List<GameQuestMission>();
        public List<GameQuestConstraint> Constraints = new List<GameQuestConstraint>();

        public static void LoadData()
        {
            DataSheet = new Dictionary<int, GameQuests>();

            var quests = new List<GameQuests>();
            string text = Config.GameDataPath + "\\System\\Quests\\";
            if (Directory.Exists(text))
            {
                foreach (GameQuests obj in Serializer.Deserialize<GameQuests>(text))
                {
                    for (var i = 0; i < obj.Missions.Count; i++)
                    {
                        obj.Missions[i].QuestId = obj.Id;
                        obj.Missions[i].MissionIndex = i;
                    }
                    quests.Add(obj);
                    DataSheet.Add((obj).Id, obj);
                }
            }

            AvailableQuests = quests.OrderBy(x => x.Id).ToArray();
        }
    }
}
