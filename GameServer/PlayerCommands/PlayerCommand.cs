using GameServer.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.PlayerCommands
{
    public abstract class PlayerCommand
    {
        public PlayerObject Player { get; set; }

        public abstract void Execute();
    }
}
