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

        public JsonMapRepository(string mapsInfoFolder)
        {
            _rootFolder = mapsInfoFolder;
        }

        public async Task Initialize()
        {
            _maps.Clear();

            var mapInfoFiles = Directory.GetFiles(_rootFolder, "*.txt", SearchOption.TopDirectoryOnly);
            var tmp = new List<MapInfo>();
            foreach (var file in mapInfoFiles)
            {
                var content = await File.ReadAllTextAsync(file, Encoding.UTF8);
                var model = JsonConvert.DeserializeObject<MapInfo>(content);
                if (model != null) tmp.Add(model);
            }

            _maps.AddRange(tmp.OrderBy(x => x.MapName).ToArray());
        }
    }
}
