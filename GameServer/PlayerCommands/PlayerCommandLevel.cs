using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.PlayerCommands
{
    public class PlayerCommandLevel : PlayerCommand
    {
        [Field(Position = 0)]
        public byte Level;

        public override void Execute()
        {
            Player.CurrentLevel = Level;
            Player.CurrentExp = 1;
            Player.玩家升级处理();
            Player.SendPacket(new CharacterExpChangesPacket
            {
                经验增加 = 0,
                今日增加 = 0,
                经验上限 = 10000000,
                DoubleExp = 0,
                CurrentExp = Player.CurrentExp,
                升级所需 = Player.MaxExperience
            });

        }
    }
}
