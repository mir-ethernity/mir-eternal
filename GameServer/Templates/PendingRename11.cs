using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace GameServer.Templates
{
	
	public sealed class 守卫刷新
	{
		
		public static void LoadData()
		{
			守卫刷新.DataSheet = new HashSet<守卫刷新>();
			string text = CustomClass.GameData目录 + "\\System\\GameMap\\GuardRefresh\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in 序列化类.反序列化(text, typeof(守卫刷新)))
				{
					守卫刷新.DataSheet.Add((守卫刷新)obj);
				}
			}
		}

		
		public 守卫刷新()
		{
			
			
		}

		
		public static HashSet<守卫刷新> DataSheet;

		
		public ushort 守卫编号;

		
		public byte 所处地图;

		
		public string 所处地名;

		
		public Point 所处坐标;

		
		public GameDirection 所处方向;

		
		public string 区域名字;
	}
}
