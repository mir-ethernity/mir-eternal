using ContentEditor.Repository;
using ContentEditor.Repository.Default;
using ContentEditor.Repository.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentEditor.Services.JSON
{
    public class JsonDatabaseManager : IDatabaseManager
    {
        public string SystemFolderPath { get; private set; }

        public IMapRepository Map { get; private set; }
        public ITerrainRepository Terrain { get; private set; }
        public IItemRepository Item { get; private set; }

        public JsonDatabaseManager(string systemFolderPath)
        {
            SystemFolderPath = systemFolderPath;

            Map = new JsonMapRepository(Path.Combine(systemFolderPath, "GameMap"));
            Item = new JsonItemRepository(Path.Combine(systemFolderPath, "Items"));

            Terrain = new DefaultTerrainRepository(Path.Combine(systemFolderPath, "GameMap", "Terrains"));
        }

        public async Task Initialize()
        {
            var properties = typeof(JsonDatabaseManager)
                .GetProperties()
                .Where(x => x.PropertyType.IsAssignableTo(typeof(IRepository)))
                .ToList();

            var tasks = new List<Task>();

            foreach(var property in properties)
            {
                var repository = property.GetValue(this) as IRepository;
                if (repository == null) continue;
                tasks.Add(repository.Initialize());
            }

            await Task.WhenAll(tasks);
        }
    }
}
