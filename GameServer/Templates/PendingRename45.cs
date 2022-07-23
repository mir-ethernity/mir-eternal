using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	
	public sealed class 游戏称号
	{
		
		public static void LoadData()
		{
			游戏称号.DataSheet = new Dictionary<byte, 游戏称号>();
			string text = CustomClass.GameDataPath + "\\System\\Items\\GameTitle\\";
			if (Directory.Exists(text))
			{
				object[] array = Serializer.Deserialize(text, typeof(游戏称号));
				for (int i = 0; i < array.Length; i++)
				{
					游戏称号 游戏称号 = array[i] as 游戏称号;
					游戏称号.DataSheet.Add(游戏称号.称号编号, 游戏称号);
				}
			}
		}

		
		public 游戏称号()
		{
			
			
		}

		
		public static Dictionary<byte, 游戏称号> DataSheet;

		
		public byte 称号编号;

		
		public string 称号名字;

		
		public int 称号战力;

		
		public int 有效时间;

		
		public Dictionary<GameObjectStats, int> 称号属性;
	}
}
