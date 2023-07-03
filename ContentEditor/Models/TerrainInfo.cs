namespace ContentEditor.Models
{
    public class TerrainInfo
    {
        public int Width;
        public int Height;
        public TerrainCellInfo[,] Cells;

        public int StartX { get; internal set; }
        public int StartY { get; internal set; }
        public int EndX { get; internal set; }
        public int EndY { get; internal set; }

        public static implicit operator TerrainInfo(MapInfo v)
        {
            throw new NotImplementedException();
        }
    }
}
