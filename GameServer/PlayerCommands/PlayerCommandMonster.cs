using GameServer.Maps;
using GameServer.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.PlayerCommands
{
    public class PlayerCommandMonster : PlayerCommand
    {
        [Field(Position = 0)]
        public string MonsterName;

        [Field(Position = 1, IsOptional = true)]
        public int? Qty;

        public override void Execute()
        {
            if (!Monsters.DataSheet.TryGetValue(MonsterName, out Monsters monster))
            {
                Player.SendMessage($"Mob {MonsterName} does not exist");
                return;
            }

            var qty = Qty ?? 1;
            for (var i = 0; i < qty; i++)
                new MonsterObject(monster, Player.CurrentMap, int.MaxValue, new System.Drawing.Point[] { Player.CurrentPosition }, true, true) { 存活时间 = MainProcess.CurrentTime.AddMinutes(1.0) };
        }
    }
}
