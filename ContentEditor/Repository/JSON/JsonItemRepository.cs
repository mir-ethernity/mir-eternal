using ContentEditor.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentEditor.Repository.JSON
{
    public class JsonItemRepository : IItemRepository
    {
        private List<GameItem> _items = new List<GameItem>();
        private readonly string _rootFolder;

        public IEnumerable<GameItem> DataSource => _items;

        public JsonItemRepository(string itemsFolder)
        {
            _rootFolder = itemsFolder;
        }

        public async Task Initialize()
        {
            _items.Clear();

            var itemFiles = Directory.GetFiles(Path.Combine(_rootFolder, "Common"), "*.txt", SearchOption.TopDirectoryOnly);
            var tmp = new List<GameItem>();

            foreach (var file in itemFiles)
            {
                var content = await File.ReadAllTextAsync(file, Encoding.UTF8);
                var model = JsonConvert.DeserializeObject<GameItem>(content);
                if (model != null) tmp.Add(model);
            }

            _items.AddRange(tmp.OrderBy(x => x.Name).ToArray());
        }
    }
}
