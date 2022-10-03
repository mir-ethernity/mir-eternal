using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.PlayerCommands
{
    public class PlayerCommandAddTitle : PlayerCommand
    {
        [Field(Position = 0)]
        public byte Id;

        public override void Execute()
        {
            Player.ObtainTitle(Id);
        }
    }
}