using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Templates
{
    public enum RewardType
    {
        Gold = 0,
        Exp = 1,
        Item = 2
    }

    public enum QuestMissionType
    {
        AdquireItem = 0,
        SpeakWithNPC = 1,
        KillMob = 2,
        EquipSword = 3
    }

    public enum QuestAcceptConstraint
    {
        QuestCompleted = 0
    }

    public class GameQuestReward
    {
        public RewardType Type { get; set; }
        public int Value { get; set; }
        public int Amount { get; set; }
    }

    public class GameQuestMission
    {
        public GameQuests Quest { get; set; }
        public QuestMissionType Type { get; set; }
        public int Value { get; set; }
        public int? RequireAmount { get; set; } = null;
    }

    public class GameQuestConstraint
    {
        public QuestAcceptConstraint Type { get; set; }
        public int Value { get; set; }
    }

    public class GameQuests
    {
        public static IDictionary<int, GameQuests> DataSheet;
        public static IEnumerable<GameQuests> AvailableQuests;

        public int Id;
        public int Chapter;
        public byte QuestLevel;
        public string Name;
        public int FinishNpcId;
        public List<GameQuestReward> Rewards = new List<GameQuestReward>();
        public List<GameQuestMission> Missions = new List<GameQuestMission>();
        public List<GameQuestConstraint> Constraints = new List<GameQuestConstraint>();

        public static void LoadData()
        {
            DataSheet = new Dictionary<int, GameQuests>();

            var quests = new List<GameQuests>();

            quests.Add(new GameQuests
            {
                Id = 1441,
                Name = "The Arousal (I)",
                QuestLevel = 1,
                Chapter = 1,
                FinishNpcId = 6683,
                Rewards = new List<GameQuestReward>
                {
                    new GameQuestReward { Type = RewardType.Gold, Amount = 20 },
                    new GameQuestReward { Type = RewardType.Exp, Amount = 40 },
                },
            });

            quests.Add(new GameQuests
            {
                Id = 1442,
                Name = "The Arousal (II)",
                QuestLevel = 1,
                Chapter = 1,
                FinishNpcId = 6684,
                Constraints = new List<GameQuestConstraint>()
                {
                    new GameQuestConstraint { Type = QuestAcceptConstraint.QuestCompleted, Value = 1441 }
                },
                Rewards = new List<GameQuestReward>
                {
                    new GameQuestReward { Type = RewardType.Gold, Amount = 20 },
                    new GameQuestReward { Type = RewardType.Exp, Amount = 40 },
                },
            });

            quests.Add(new GameQuests
            {
                Id = 1443,
                Name = "The Arousal (III)",
                QuestLevel = 2,
                Chapter = 1,
                FinishNpcId = 6684,
                Constraints = new List<GameQuestConstraint>()
                {
                    new GameQuestConstraint { Type = QuestAcceptConstraint.QuestCompleted, Value = 1442 }
                },
                Missions = new List<GameQuestMission>
                {
                    new GameQuestMission { Type = QuestMissionType.EquipSword },
                },
                Rewards = new List<GameQuestReward>
                {
                    new GameQuestReward { Type = RewardType.Gold, Amount = 60 },
                    new GameQuestReward { Type = RewardType.Exp, Amount = 50 },
                    new GameQuestReward { Type = RewardType.Item, Value = 2326, Amount = 50 }
                },
            });

            quests.Add(new GameQuests
            {
                Id = 1445,
                Name = "The Arousal (IV)",
                QuestLevel = 2,
                Chapter = 1,
                FinishNpcId = 6684,
                Constraints = new List<GameQuestConstraint>()
                {
                    new GameQuestConstraint { Type = QuestAcceptConstraint.QuestCompleted, Value = 1443 }
                },
                Missions = new List<GameQuestMission>
                {
                    new GameQuestMission { Type = QuestMissionType.KillMob, Value = 819, RequireAmount = 5 },
                },
                Rewards = new List<GameQuestReward>
                {
                    new GameQuestReward { Type = RewardType.Gold, Amount = 240 },
                    new GameQuestReward { Type = RewardType.Exp, Amount = 200 },
                },
            });


            quests.Add(new GameQuests
            {
                Id = 1446,
                Name = "The Arousal (V)",
                QuestLevel = 3,
                Chapter = 1,
                FinishNpcId = 6684,
                Constraints = new List<GameQuestConstraint>()
                {
                    new GameQuestConstraint { Type = QuestAcceptConstraint.QuestCompleted, Value = 1445 }
                },
                Missions = new List<GameQuestMission>
                {
                    new GameQuestMission { Type = QuestMissionType.AdquireItem, Value = 303, RequireAmount = 1 }
                },
                Rewards = new List<GameQuestReward>
                {
                    new GameQuestReward { Type = RewardType.Gold, Amount = 240 },
                    new GameQuestReward { Type = RewardType.Exp, Amount = 200 },
                },
            });

            foreach (var quest in quests)
            {
                DataSheet.Add(quest.Id, quest);

                foreach (var constraint in quest.Missions)
                    constraint.Quest = quest;
            }

            AvailableQuests = quests.ToArray();
        }
    }
}
