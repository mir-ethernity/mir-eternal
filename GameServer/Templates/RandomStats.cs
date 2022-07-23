using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	public sealed class RandomStats
	{
		public static Dictionary<int, RandomStats> DataSheet;

		public GameObjectStats Stat;
		public int Value;
		public int StatId;
		public int CombatBonus;
		public string StatDescription;

		public static void LoadData()
		{
			DataSheet = new Dictionary<int, RandomStats>();
			var text = CustomClass.GameDataPath + "\\System\\Items\\RandomStats\\";

			if (Directory.Exists(text))
			{
				foreach (object obj in Serializer.Deserialize(text, typeof(RandomStats)))
				{
					DataSheet.Add(((RandomStats)obj).StatId, (RandomStats)obj);
				}
			}
		}
	}
}
