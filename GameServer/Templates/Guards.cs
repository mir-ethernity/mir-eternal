using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace GameServer.Templates
{
	public sealed class Guards
	{
		public static HashSet<Guards> DataSheet;

		public ushort GuardNumber;
		public byte FromMapId;
		public string FromMapName;
		public Point FromCoords;
		public GameDirection Direction;
		public string RegionName;

		public static void LoadData()
		{
			DataSheet = new HashSet<Guards>();
			string text = CustomClass.GameDataPath + "\\System\\GameMap\\Guards\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in Serializer.Deserialize(text, typeof(Guards)))
				{
					DataSheet.Add((Guards)obj);
				}
			}
		}
	}
}
