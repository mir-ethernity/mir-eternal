using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	
	public sealed class 游戏地图
	{
		
		public static void LoadData()
		{
			游戏地图.DataSheet = new Dictionary<byte, 游戏地图>();
			string text = CustomClass.GameData目录 + "\\System\\GameMap\\Maps";
			if (Directory.Exists(text))
			{
				foreach (object obj in 序列化类.反序列化(text, typeof(游戏地图)))
				{
					游戏地图.DataSheet.Add(((游戏地图)obj).地图编号, (游戏地图)obj);
				}
			}
		}

		
		public override string ToString()
		{
			return this.地图名字;
		}

		
		public 游戏地图()
		{
			
			
		}

		
		public static Dictionary<byte, 游戏地图> DataSheet;

		
		public byte 地图编号;

		
		public string 地图名字;

		
		public string 地图别名;

		
		public string 地形文件;

		
		public int 限制人数;

		
		public byte 限制等级;

		
		public byte 分线数量;

		
		public bool 下线传送;

		
		public byte 传送地图;

		
		public bool 副本地图;
	}
}
