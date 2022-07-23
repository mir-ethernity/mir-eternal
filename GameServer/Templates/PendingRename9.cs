using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	public sealed class RandomStats
	{
		public static Dictionary<int, RandomStats> DataSheet;

		public GameObjectProperties 对应属性;
		public int 属性数值;
		public int 属性编号;
		public int 战力加成;
		public string 属性描述;

		public static void LoadData()
		{
			DataSheet = new Dictionary<int, RandomStats>();
			var text = CustomClass.GameDataPath + "\\System\\Items\\RandomStats\\";

			if (Directory.Exists(text))
			{
				foreach (object obj in Serializer.Deserialize(text, typeof(RandomStats)))
				{
					DataSheet.Add(((RandomStats)obj).属性编号, (RandomStats)obj);
				}
			}
		}
	}
}
