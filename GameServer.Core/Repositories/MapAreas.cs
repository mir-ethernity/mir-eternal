using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace GameServer.Templates
{
    public class MapAreas
    {
        public static List<MapAreas> DataSheet;

        public byte FromMapId;
        public string FromMapName;
        public Point FromCoords;
        public string RegionName;
        public int AreaRadius;
        public AreaType AreaType;
        public HashSet<Point> RangeCoords;

        private List<Point> _listCoords;

        public static void LoadData()
        {
            DataSheet = new List<MapAreas>();
            string text = Config.GameDataPath + "\\System\\GameMap\\MapAreas\\";
            if (Directory.Exists(text))
            {
                foreach (object obj in Serializer.Deserialize(text, typeof(MapAreas)))
                {
                    DataSheet.Add((MapAreas)obj);
                }
            }
        }


        public Point RandomCoords
        {
            get
            {
                return RangeCoordsList[MainProcess.RandomNumber.Next(RangeCoords.Count)];
            }
        }

        public List<Point> RangeCoordsList
        {
            get
            {
                if (_listCoords == null)
                    _listCoords = RangeCoords.ToList();
                return _listCoords;
            }
        }
    }
}
