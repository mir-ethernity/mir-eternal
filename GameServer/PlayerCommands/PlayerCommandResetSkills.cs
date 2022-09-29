using GameServer.Networking;
using GameServer.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.PlayerCommands
{
    public class PlayerCommandResetSkills : PlayerCommand
    {
        public override void Execute()
        {
            var mainSkills = Player.MainSkills表.Values.ToArray();

            foreach (var skill in mainSkills)
                Player.RemoveSkill(skill.SkillId.V);

            Player.CharacterData.AddStarterSkills();

            Player?.SendPacket(new SyncSkillInfoPacket
            {
                技能描述 = Player.全部技能描述()
            });

            Player?.SendPacket(new SyncSkillFieldsPacket
            {
                栏位描述 = Player.ShorcutField描述()
            });

            Player.SendMessage($"You need logout to reset skills");
        }
    }
}
