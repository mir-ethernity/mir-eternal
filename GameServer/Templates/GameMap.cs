using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
    public sealed class GameMap
    {
        public static Dictionary<byte, GameMap> DataSheet;

        public byte MapId;
        public string MapName;
        public string MapFile;
        public string TerrainFile;
        public int LimitPlayers;
        public byte MinLevel;
        public byte LimitInstances;
        public bool NoReconnect;
        public byte NoReconnectMapId;
        public bool CopyMap;

        public static void LoadData()
        {
            DataSheet = new Dictionary<byte, GameMap>();
            string text = Config.GameDataPath + "\\System\\GameMap\\Maps";
            if (Directory.Exists(text))
            {
                foreach (var obj in Serializer.Deserialize<GameMap>(text))
                    DataSheet.Add(obj.MapId, obj);
            }
        }

        public override string ToString()
        {
            return MapName;
        }
    }
}
