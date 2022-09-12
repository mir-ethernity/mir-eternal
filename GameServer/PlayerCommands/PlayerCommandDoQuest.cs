using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.PlayerCommands
{
    public class PlayerCommandDoQuest : PlayerCommand
    {
        public override void Execute()
        {
            var quests = Player.CharacterData.GetInProgressQuests();

            foreach (var quest in quests)
            {
                foreach (var mission in quest.Missions)
                {
                    if (mission.CompletedDate.V != DateTime.MinValue)
                        continue;

                    if (mission.Info.V.Type == Models.Enums.QuestMissionType.AdquireItem || mission.Info.V.Type == Models.Enums.QuestMissionType.KillMob)
                        mission.Count.V = (byte)mission.Info.V.Count;

                    mission.CompletedDate.V = MainProcess.CurrentTime;
                }

                Player.CompleteQuest(quest.Info.V.Id);
            }
        }
    }
}
