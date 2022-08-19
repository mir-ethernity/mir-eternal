using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.PlayerCommands
{

    public class PlayerCommandAddGold : PlayerCommand
    {
        [Field(Position = 0)]
        public int Amount;


        public override void Execute()
        {
            Player.NumberGoldCoins += Amount;

            Player.ActiveConnection?.SendPacket(new 货币数量变动
            {
                CurrencyType = 1,
                货币数量 = Player.NumberGoldCoins
            });
        }
    }
}
