using ContentEditor.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentEditor.Services
{
    public interface IDatabaseManager
    {
        IMapRepository Map { get; }
        ITerrainRepository Terrain { get; }
    }
}
