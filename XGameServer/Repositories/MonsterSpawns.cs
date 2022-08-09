using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace GameServer.Templates
{
	public class MonsterSpawns
	{
		public static HashSet<MonsterSpawns> DataSheet;

		public byte FromMapId;
		public string FromMapName;
		public Point FromCoords;
		public string RegionName;
		public int AreaRadius;
		public MonsterSpawnInfo[] Spawns;
		public HashSet<Point> RangeCoords;

		public static void LoadData()
		{
			DataSheet = new HashSet<MonsterSpawns>();
			var text = Path.Combine(Config.GameDataPath, "System", "GameMap", "Monsters");
			if (Directory.Exists(text))
			{
				foreach (object obj in Serializer.Deserialize(text, typeof(MonsterSpawns)))
				{
					DataSheet.Add((MonsterSpawns)obj);
				}
			}
		}
	}
}
