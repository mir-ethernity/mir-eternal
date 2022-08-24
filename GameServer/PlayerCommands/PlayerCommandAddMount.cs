using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.PlayerCommands
{
    public class PlayerCommandAddMount : PlayerCommand
    {
        [Field(Position = 0)]
        public ushort MountId;

        public override void Execute()
        {
            Player.AdquireMount(MountId);
        }
    }
}
