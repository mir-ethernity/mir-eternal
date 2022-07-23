using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace GameServer.Templates
{
	
	public class 传送法阵
	{
		
		public static void LoadData()
		{
			传送法阵.DataSheet = new List<传送法阵>();
			string text = CustomClass.GameData目录 + "\\System\\GameMap\\Array\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in 序列化类.反序列化(text, typeof(传送法阵)))
				{
					传送法阵.DataSheet.Add((传送法阵)obj);
				}
			}
		}

		
		public 传送法阵()
		{
			
			
		}

		
		public static List<传送法阵> DataSheet;

		
		public byte 法阵编号;

		
		public byte 所处地图;

		
		public byte 跳转地图;

		
		public string 法阵名字;

		
		public string 所处地名;

		
		public string 跳转地名;

		
		public string 所处别名;

		
		public string 跳转别名;

		
		public Point 所处坐标;

		
		public Point 跳转坐标;
	}
}
