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
            foreach (var item in GameItems.DataSheet)
            {
                if (item.Value.Type != ItemType.技能书籍) continue;
                if (item.Value.NeedRace != Player.CharRole) continue;
                if (item.Value.AdditionalSkill <= 0) continue;

                Player.MainSkills表.Clear();
                Player.CharacterData.ShorcutField.Clear();
                Player.CharacterData.AddStarterSkills();

                Player.SendMessage($"You need logout to reset skills");
            }
        }
    }
}
