using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentEditor.Models
{

    public class MapInfo
    {
        public byte MapId { get; set; }
        public string MapName { get; set; }
        public string MapFile { get; set; }
        public string TerrainFile { get; set; }
        public int LimitPlayers { get; set; }
        public byte MinLevel { get; set; }
        public byte LimitInstances { get; set; }
        public bool NoReconnect { get; set; }
        public byte NoReconnectMapId { get; set; }
        public bool CopyMap { get; set; }

        public List<MapGuard> Guards { get; set; } = new List<MapGuard>();
        public List<MapArea> Areas { get; set; } = new List<MapArea>();
        public List<MapTeleportGate> OutgoingGates { get; set; } = new List<MapTeleportGate>();
        public List<MapTeleportGate> IncomingGates { get; set; } = new List<MapTeleportGate>();
        public List<MapMonster> Monsters { get; set; } = new List<MapMonster>();
    }
}
