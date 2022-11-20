namespace ContentEditor.Models
{
    public class MapMonster
    {
        public int FromMapId { get; set; }
        public Point FromCoords { get; set; }
        public int AreaRadius { get; set; }
        public List<MapMonsterSpawn> Spawns { get; set; } = new List<MapMonsterSpawn>();
    }
}
