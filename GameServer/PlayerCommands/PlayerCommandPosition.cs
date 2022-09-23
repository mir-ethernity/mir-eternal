using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.PlayerCommands
{
    public class PlayerCommandPosition : PlayerCommand
    {
        public override void Execute()
        {
            Player.SendMessage($"Your are in {Player.CurrentMap.MapId} ({Player.CurrentMap.地图模板.MapName}) at X: {Player.CurrentPosition.X}, Y: {Player.CurrentPosition.Y}");
        }
    }
}
