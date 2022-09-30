﻿using ContentEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentEditor.Repository
{
    public interface ITerrainRepository
    {
        Task<TerrainInfo?> GetTerrain(string terrainFile);
    }
}