namespace ContentEditor.Models
{
    public class MapTeleportGate
    {
        public int TeleportGateNumber { get; set; }
        public int FromMapId { get; set; }
        public int ToMapId { get; set; }
        public string TeleportGateName { get; set; }
        public Point FromCoords { get; set; }
        public Point ToCoords { get; set; }
    }
}
