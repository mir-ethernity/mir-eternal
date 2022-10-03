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

        public JsonDatabaseManager(string systemFolderPath)
        {
            SystemFolderPath = systemFolderPath;

            Map = new JsonMapRepository(Path.Combine(systemFolderPath, "GameMap"));
            Terrain = new DefaultTerrainRepository(Path.Combine(systemFolderPath, "GameMap", "Terrains"));
        }
    }
}
