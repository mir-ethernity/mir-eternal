using GameServer.Enums;
using GameServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentEditor.Models
{
    public class GameItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxDura { get; set; }
        public int Weight { get; set; }
        public int Level { get; set; }
        public int NeedLevel { get; set; }
        public int Cooldown { get; set; }
        public byte Group { get; set; }
        public int GroupCooling { get; set; }
        public int SalePrice { get; set; }
        public ushort AdditionalSkill { get; set; }
        public bool IsBound { get; set; }
        public bool CanDrop { get; set; }
        public bool CanSold { get; set; }
        public bool ValuableObjects { get; set; }
        public int? UnpackItemId { get; set; }

        public ItemType Type { get; set; }
        public GameObjectRace NeedRace { get; set; }
        public GameObjectGender NeedGender { get; set; }
        public PersistentItemType PersistType { get; set; }
        public ItemsForSale StoreType { get; set; }

        public IDictionary<ItemProperty, int> Props = new Dictionary<ItemProperty, int>();
    }
}
