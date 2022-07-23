using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace GameServer.Templates
{
	
	public class 怪物刷新
	{
		
		public static void LoadData()
		{
			怪物刷新.DataSheet = new HashSet<怪物刷新>();
			string text = CustomClass.GameDataPath + "\\System\\GameMap\\MonsterRefresh\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in Serializer.Deserialize(text, typeof(怪物刷新)))
				{
					怪物刷新.DataSheet.Add((怪物刷新)obj);
				}
			}
		}

		
		public 怪物刷新()
		{
			
			
		}

		
		public static HashSet<怪物刷新> DataSheet;

		
		public byte FromMapId;

		
		public string FromMapName;

		
		public Point FromCoords;

		
		public string 区域名字;

		
		public int 区域半径;

		
		public 刷新信息[] 刷新列表;

		
		public HashSet<Point> 范围坐标;
	}
}
