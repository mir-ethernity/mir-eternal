using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace GameServer.Templates
{
	public class TeleportGates
	{
		public static List<TeleportGates> DataSheet;

		public byte TeleportGateNumber;
		public byte FromMapId;
		public byte ToMapId;
		public string TeleportGateName;
		public string FromMapName;
		public string ToMapName;
		public string FromMapFile;
		public string ToMapFile;
		public Point FromCoords;
		public Point ToCoords;

		public static void LoadData()
		{
			DataSheet = new List<TeleportGates>();
			string text = Config.GameDataPath + "\\System\\GameMap\\TeleportGates\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in Serializer.Deserialize(text, typeof(TeleportGates)))
				{
					DataSheet.Add((TeleportGates)obj);
				}
			}
		}
	}
}
