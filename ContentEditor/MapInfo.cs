using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentEditor
{
    public class CellInfo
    {
        public ushort Height;
        public bool IsBlocked;
        public bool IsFreeZone;
        public bool IsSafeZone;
        public bool IsStallArea;
        public bool IsWalkable1;
        public bool IsWalkable2;
    }

    public class MapInfo
    {
        public int Width;
        public int Height;
        public CellInfo[,] Cells;
    }

}
