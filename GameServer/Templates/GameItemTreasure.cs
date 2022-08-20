using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Templates
{
    public class GameItemTreasure
    {
        public string ItemName { get; set; }
        public GameObjectRace? NeedRace { get; set; } = null;
        public int? Rate { get; set; } = null;
    }
}
