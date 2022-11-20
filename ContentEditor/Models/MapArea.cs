using GameServer.Templates;

namespace ContentEditor.Models
{
    public class MapArea
    {
        public int FromMapId { get; set; }
        public Point FromCoords { get; set; }
        public string RegionName { get; set; } = "";
        public int AreaRadius { get; set; }
        public AreaType AreaType { get; set; }
    }
}
