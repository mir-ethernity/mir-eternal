using GameServer.Data;
using GameServer.Networking;
using GameServer.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.PlayerCommands
{
    public class PlayerCommandMake : PlayerCommand
    {
        [Field(Position = 0)]
        public string ItemName;

        [Field(Position = 1, IsOptional = true)]
        public int Qty = 1;

        public override void Execute()
        {
            if (!GameItems.DataSheetByName.TryGetValue(ItemName, out var itemTemplate))
            {
                Player.SendMessage("Item does not exist");
                return;
            }

            if (Qty > Player.BackpackSizeAvailable)
            {
                Player.SendMessage("Your bag is full");
                return;
            }

            if (itemTemplate.MaxDura == 0)
            {
                Player.SendMessage("This item can not be maked");
                return;
            }

            if (!Player.CharacterData.TryGetFreeSpaceAtInventory(out byte b))
            {
                Player.SendMessage("Your bag is full");
                return;
            }

            Player.GainItem(itemTemplate, b, Qty);
        }
    }
}
