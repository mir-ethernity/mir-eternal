using GameServer.Templates;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Data
{

    public class CharacterQuest : GameData
    {
        public DataMonitor<CharacterData> Character;
        public readonly DataMonitor<GameQuests> Info;
        public readonly DataMonitor<DateTime> StartDate;
        public readonly DataMonitor<DateTime> CompleteDate;
        public readonly HashMonitor<CharacterQuestMission> Missions;

        public bool IsCompleted => Missions.All(x => x.CompletedDate.V != DateTime.MinValue);

        public static CharacterQuest Create(CharacterData character, GameQuests gameQuest)
        {
            var charQuest = new CharacterQuest();

            charQuest.Character.V = character;
            charQuest.Info.V = gameQuest;
            charQuest.StartDate.V = MainProcess.CurrentTime;

            foreach (var mission in gameQuest.Missions)
            {
                if (mission.Role != null && mission.Role.Value != character.CharRace.V) continue;

                charQuest.Missions.Add(CharacterQuestMission.Create(charQuest, mission));
            }

            GameDataGateway.CharacterQuestDataTable.AddData(charQuest, true);

            return charQuest;
        }

        public override void Delete()
        {
            foreach (var constraint in Missions)
                constraint.Delete();

            base.Delete();
        }

        public CharacterQuestMission[] GetMissionsOfType(QuestMissionType type)
        {
            return Missions
                .Where(x => x.Info.V.Type == type)
                .ToArray();
        }
    }
}
