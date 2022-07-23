using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	
	public sealed class 随机属性
	{
		
		public static void LoadData()
		{
			随机属性.DataSheet = new Dictionary<int, 随机属性>();
			string text = CustomClass.GameData目录 + "\\System\\Items\\RandomStats\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in 序列化类.反序列化(text, typeof(随机属性)))
				{
					随机属性.DataSheet.Add(((随机属性)obj).属性编号, (随机属性)obj);
				}
			}
		}

		
		public 随机属性()
		{
			
			
		}

		
		public static Dictionary<int, 随机属性> DataSheet;

		
		public GameObjectProperties 对应属性;

		
		public int 属性数值;

		
		public int 属性编号;

		
		public int 战力加成;

		
		public string 属性描述;
	}
}
