using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	public sealed class GameTitle
	{
		public static Dictionary<byte, GameTitle> DataSheet;

		public byte Id;
		public string Name;
		public int Combat;
		public int EffectiveTime;
		public Dictionary<GameObjectStats, int> Attributes;

		public static void LoadData()
		{
			DataSheet = new Dictionary<byte, GameTitle>();
			string text = Config.GameDataPath + "\\System\\Items\\GameTitle\\";
			if (Directory.Exists(text))
			{
				object[] array = Serializer.Deserialize(text, typeof(GameTitle));
				for (int i = 0; i < array.Length; i++)
				{
					GameTitle title = array[i] as GameTitle;
					DataSheet.Add(title.Id, title);
				}
			}
		}
	}
}
