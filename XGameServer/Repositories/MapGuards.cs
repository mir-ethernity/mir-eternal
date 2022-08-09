using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace GameServer.Templates
{
	public sealed class MapGuards
	{
		public static HashSet<MapGuards> DataSheet;

		public ushort GuardNumber;
		public byte FromMapId;
		public string FromMapName;
		public Point FromCoords;
		public GameDirection Direction;
		public string RegionName;

		public static void LoadData()
		{
			DataSheet = new HashSet<MapGuards>();
			var text = Path.Combine(Config.GameDataPath, "System", "GameMap", "Guards");
			if (Directory.Exists(text))
			{
				foreach (object obj in Serializer.Deserialize(text, typeof(MapGuards)))
				{
					DataSheet.Add((MapGuards)obj);
				}
			}
		}
	}
}
