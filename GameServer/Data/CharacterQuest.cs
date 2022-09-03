using GameServer.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Data
{
    public class CharacterQuestMission : GameData
    {
        public DataMonitor<CharacterQuest> CharacterQuest;
        public DataMonitor<GameQuestMission> Info;
        public DataMonitor<DateTime> CompletedDate;
        public DataMonitor<int> Amount;

        public static CharacterQuestMission Create(CharacterQuest characterQuest, GameQuestMission constraint)
        {
            var charConstraint = new CharacterQuestMission();
            charConstraint.CharacterQuest.V = characterQuest;
            charConstraint.Info.V = constraint;
            charConstraint.Amount.V = 0;

            GameDataGateway.CharacterQuestConstraintDataTable.AddData(charConstraint, true);

            return charConstraint;
        }
    }

    public class CharacterQuest : GameData
    {
        public DataMonitor<CharacterData> Character;
        public readonly DataMonitor<GameQuests> Info;
        public readonly DataMonitor<DateTime> StartDate;
        public readonly DataMonitor<DateTime> CompleteDate;
        public readonly HashMonitor<CharacterQuestMission> Missions;

        public static CharacterQuest Create(CharacterData character, GameQuests gameQuest)
        {
            var charQuest = new CharacterQuest();

            charQuest.Character.V = character;
            charQuest.Info.V = gameQuest;
            charQuest.StartDate.V = MainProcess.CurrentTime;

            foreach (var constraint in gameQuest.Missions)
                charQuest.Missions.Add(CharacterQuestMission.Create(charQuest, constraint));

            GameDataGateway.CharacterQuestDataTable.AddData(charQuest, true);

            return charQuest;
        }

        public override void Delete()
        {
            foreach (var constraint in Missions)
                constraint.Delete();

            base.Delete();
        }
    }
}
