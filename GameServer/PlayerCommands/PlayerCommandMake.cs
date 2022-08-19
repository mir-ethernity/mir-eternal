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

            if (itemTemplate is EquipmentItem equipItem)
            {
                Player.CharacterData.Backpack[b] = new EquipmentData(equipItem, Player.CharacterData, 1, b, true);
            }
            else if (itemTemplate.PersistType == PersistentItemType.容器)
            {
                Player.CharacterData.Backpack[b] = new ItemData(itemTemplate, Player.CharacterData, 1, b, 0);
            }
            else if (itemTemplate.PersistType == PersistentItemType.堆叠)
            {
                Player.CharacterData.Backpack[b] = new ItemData(itemTemplate, Player.CharacterData, 1, b, 1);
            }
            else
            {
                Player.CharacterData.Backpack[b] = new ItemData(itemTemplate, Player.CharacterData, 1, b, itemTemplate.MaxDura);
            }

            if (Qty > 1) Player.CharacterData.Backpack[b].当前持久.V = Qty;

            Player.ActiveConnection?.SendPacket(new 玩家物品变动
            {
                物品描述 = Player.CharacterData.Backpack[b].字节描述()
            });
        }
    }
}
