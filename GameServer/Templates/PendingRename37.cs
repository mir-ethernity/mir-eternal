using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace GameServer.Templates
{
	
	public class 地图区域
	{
		
		public static void LoadData()
		{
			地图区域.DataSheet = new List<地图区域>();
			string text = CustomClass.GameDataPath + "\\System\\GameMap\\MapArea\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in Serializer.Deserialize(text, typeof(地图区域)))
				{
					地图区域.DataSheet.Add((地图区域)obj);
				}
			}
		}

		
		// (get) Token: 0x06000684 RID: 1668 RVA: 0x00005E2B File Offset: 0x0000402B
		public Point 随机坐标
		{
			get
			{
				return this.范围坐标列表[MainProcess.RandomNumber.Next(this.范围坐标列表.Count)];
			}
		}

		
		// (get) Token: 0x06000685 RID: 1669 RVA: 0x00005E4D File Offset: 0x0000404D
		public List<Point> 范围坐标列表
		{
			get
			{
				if (this._范围坐标列表 == null)
				{
					this._范围坐标列表 = this.范围坐标.ToList<Point>();
				}
				return this._范围坐标列表;
			}
		}

		
		public 地图区域()
		{
			
			
		}

		
		public static List<地图区域> DataSheet;

		
		public byte FromMapId;

		
		public string FromMapName;

		
		public Point FromCoords;

		
		public string 区域名字;

		
		public int 区域半径;

		
		public 地图区域类型 区域类型;

		
		public HashSet<Point> 范围坐标;

		
		private List<Point> _范围坐标列表;
	}
}
