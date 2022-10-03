using ContentEditor.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentEditor.Repository.JSON
{
    public class JsonMapRepository : IMapRepository
    {
        private readonly string _rootFolder;
        private List<MapInfo> _maps = new List<MapInfo>();

        public IEnumerable<MapInfo> DataSource => _maps;

        public JsonMapRepository(string mapsFolder)
        {
            _rootFolder = mapsFolder;
        }

        public async Task Initialize()
        {
            _maps.Clear();

            var mapInfoFiles = Directory.GetFiles(Path.Combine(_rootFolder, "Maps"), "*.txt", SearchOption.TopDirectoryOnly);
            var tmp = new List<MapInfo>();
            foreach (var file in mapInfoFiles)
            {
                var content = await File.ReadAllTextAsync(file, Encoding.UTF8);
                var model = JsonConvert.DeserializeObject<MapInfo>(content);
                if (model != null) tmp.Add(model);
            }

            var guardFiles = Directory.GetFiles(Path.Combine(_rootFolder, "Guards"), "*.txt", SearchOption.TopDirectoryOnly);
            foreach (var guardFile in guardFiles)
            {
                var content = await File.ReadAllTextAsync(guardFile, Encoding.UTF8);
                var model = JsonConvert.DeserializeObject<MapGuard>(content);
                if (model != null)
                {
                    var map = tmp.FirstOrDefault(x => x.MapId == model.FromMapId);
                    if (map == null) continue;
                    map.Guards.Add(model);
                }
            }

            var areaFiles = Directory.GetFiles(Path.Combine(_rootFolder, "MapAreas"), "*.txt", SearchOption.TopDirectoryOnly);
            foreach (var areaFile in areaFiles)
            {
                var content = await File.ReadAllTextAsync(areaFile, Encoding.UTF8);
                var model = JsonConvert.DeserializeObject<MapArea>(content);
                if (model != null)
                {
                    var map = tmp.FirstOrDefault(x => x.MapId == model.FromMapId);
                    if (map == null) continue;
                    map.Areas.Add(model);
                }
            }

            var teleportGates = Directory.GetFiles(Path.Combine(_rootFolder, "TeleportGates"), "*.txt", SearchOption.TopDirectoryOnly);
            foreach (var teleportGateFile in teleportGates)
            {
                var content = await File.ReadAllTextAsync(teleportGateFile, Encoding.UTF8);
                var model = JsonConvert.DeserializeObject<MapTeleportGate>(content);
                if (model != null)
                {
                    var mapIn = tmp.FirstOrDefault(x => x.MapId == model.FromMapId);
                    if (mapIn != null) mapIn.OutgoingGates.Add(model);

                    var mapOut = tmp.FirstOrDefault(x => x.MapId == model.ToMapId);
                    if (mapOut != null) mapOut.IncomingGates.Add(model);
                }
            }

            var monsterFiles = Directory.GetFiles(Path.Combine(_rootFolder, "Monsters"), "*.txt", SearchOption.TopDirectoryOnly);
            foreach (var monsterFile in monsterFiles)
            {
                var content = await File.ReadAllTextAsync(monsterFile, Encoding.UTF8);
                var model = JsonConvert.DeserializeObject<MapMonster>(content);
                if (model != null)
                {
                    var map = tmp.FirstOrDefault(x => x.MapId == model.FromMapId);
                    if (map != null) map.Monsters.Add(model);
                }
            }

            _maps.AddRange(tmp.OrderBy(x => x.MapName).ToArray());
        }
    }
}
