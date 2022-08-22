using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Templates
{
    public class ChestTemplate
    {
        public static Dictionary<int, ChestTemplate> DataSheet;

        public int Id { get; set; }
        public string Name { get; set; }
        public GameItemTreasure[] Items { get; set; }


        public static void LoadData()
        {
            string text = Config.GameDataPath + "\\System\\Npc\\Chests\\";

            if (Directory.Exists(text))
                DataSheet = Serializer.Deserialize<ChestTemplate>(text).ToDictionary(x => x.Id);
            else
                DataSheet = new Dictionary<int, ChestTemplate>();
        }
    }
}
