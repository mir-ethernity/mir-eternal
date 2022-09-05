using GameServer;
using Models.Enums;
using System.Text.Json.Serialization;

namespace Models
{
    public class GameQuestMission
    {
        [JsonIgnore]
        public int QuestId { get; set; }
        [JsonIgnore]
        public int MissionIndex { get; set; }

        public QuestMissionType Type { get; set; }
        public GameObjectRace? Role { get; set; } = null;
        public int Id { get; set; }
        public int Count { get; set; }
    }
}
