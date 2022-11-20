using ContentEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentEditor.Repository.Default
{
    public class DefaultTerrainRepository : ITerrainRepository
    {
        public string TerrainsFolder { get; }

        public DefaultTerrainRepository(string terrainsFolder)
        {
            TerrainsFolder = terrainsFolder;
        }


        public async Task<TerrainInfo?> GetTerrain(string terrainFile)
        {
            var path = Path.Combine(TerrainsFolder, terrainFile + ".terrain");

            if (!File.Exists(path))
                return null;

            var terrain = new TerrainInfo();

            var fileContent = await File.ReadAllBytesAsync(path);

            using var ms = new MemoryStream(fileContent);
            using var br = new BinaryReader(ms);

            var sx = br.ReadInt32();
            var sy = br.ReadInt32();
            var ex = br.ReadInt32();
            var ey = br.ReadInt32();
            var hx = br.ReadInt32();
            var hy = br.ReadInt32();

            terrain.StartX = sx;
            terrain.StartY = sy;
            terrain.EndX = ex;
            terrain.EndY = ey;

            terrain.Width = ex - sx;
            terrain.Height = ey - sy;

            terrain.Cells = new TerrainCellInfo[terrain.Width, terrain.Height];

            for (var x = 0; x < terrain.Width; x++)
            {
                for (var y = 0; y < terrain.Height; y++)
                {
                    var cell = terrain.Cells[x, y] = new TerrainCellInfo();

                    var cellFlag = br.ReadInt32();
                    var terrainHeight = (ushort)(cellFlag & 65535U) - 30U;

                    cell.IsBlocked = (cellFlag & 268435456U) != 268435456U;
                    cell.IsFreeZone = (cellFlag & 131072U) == 131072U;
                    cell.IsSafeZone = (cellFlag & 262144U) == 262144U;
                    cell.IsStallArea = (cellFlag & 1048576U) == 1048576U;
                    cell.IsWalkable1 = (cellFlag & 4194304U) == 4194304U;
                    cell.IsWalkable2 = (cellFlag & 8388608U) == 8388608U;
                }
            }

            return terrain;
        }
    }
}
