namespace ContentEditor.Models
{
    public class TerrainInfo
    {
        public int Width;
        public int Height;
        public TerrainCellInfo[,] Cells;

        public static implicit operator TerrainInfo(MapInfo v)
        {
            throw new NotImplementedException();
        }
    }
}
