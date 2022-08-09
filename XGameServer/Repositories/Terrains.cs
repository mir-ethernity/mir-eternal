using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace GameServer.Templates
{
    public sealed class Terrains
    {
        public static Dictionary<byte, Terrains> DataSheet;

        public byte MapId;
        public string MapName;
        public Point StartPoint;
        public Point EndPoint;
        public Point MapSize;
        public Point MapHeight;
        public uint[,] Matrix;

        private static Terrains LoadTerrainFromFile(FileSystemInfo fileInfo)
        {
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileInfo.Name);
            var parts = fileNameWithoutExtension.Split('-');

            var terrain = new Terrains
            {
                MapName = parts[1],
                MapId = Convert.ToByte(parts[0])
            };

            using (var ms = new MemoryStream(File.ReadAllBytes(fileInfo.FullName)))
            {
                using var br = new BinaryReader(ms);

                terrain.StartPoint = new Point(br.ReadInt32(), br.ReadInt32());
                terrain.EndPoint = new Point(br.ReadInt32(), br.ReadInt32());
                terrain.MapSize = new Point(terrain.EndPoint.X - terrain.StartPoint.X, terrain.EndPoint.Y - terrain.StartPoint.Y);
                terrain.MapHeight = new Point(br.ReadInt32(), br.ReadInt32());
                terrain.Matrix = new uint[terrain.MapSize.X, terrain.MapSize.Y];

                for (int i = 0; i < terrain.MapSize.X; i++)
                {
                    for (int j = 0; j < terrain.MapSize.Y; j++)
                    {
                        terrain.Matrix[i, j] = br.ReadUInt32();
                    }
                }
            }

            return terrain;
        }


        public static void LoadData()
        {
            DataSheet = new Dictionary<byte, Terrains>();
            var path = Path.Combine(Config.GameDataPath, "System", "GameMap", "Terrains");
            if (Directory.Exists(path))
            {
                var terrains = new ConcurrentBag<Terrains>();
                var terrainFiles = new DirectoryInfo(path).GetFiles("*.terrain");

                Parallel.ForEach(terrainFiles, delegate (FileInfo x)
                {
                    var terrain = LoadTerrainFromFile(x);
                    terrains.Add(terrain);
                });

                foreach (var terrain in terrains)
                    DataSheet.Add(terrain.MapId, terrain);
            }
        }


        public uint this[Point point]
        {
            get
            {
                return this.Matrix[point.X - this.StartPoint.X, point.Y - this.StartPoint.Y];
            }
        }
    }
}
