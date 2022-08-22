using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Templates
{
    public class MapChest
    {
        public static HashSet<MapChest> DataSheet;

        public int ChestId { get; set; }
        public int MapId { get; set; }
        public Point Coords { get; set; }
        public GameDirection Direction { get; set; }

        public static void LoadData()
        {
            string text = Config.GameDataPath + "\\System\\GameMap\\Chests\\";

            if (Directory.Exists(text))
                DataSheet = new HashSet<MapChest>(Serializer.Deserialize<MapChest>(text));
            else
                DataSheet = new HashSet<MapChest>();
        }

    }
}
