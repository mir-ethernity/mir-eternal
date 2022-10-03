using GameServer;

namespace ContentEditor.Models
{
    public class MapGuard
    {
        public int GuardNumber { get; set; }
        public int FromMapId { get; set; }
        public Point FromCoords { get; set; }
        public GameDirection Direction { get; set; }
    }
}
