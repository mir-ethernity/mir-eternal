using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace GameServer.Templates
{
	// Token: 0x02000285 RID: 645
	public class 地图区域
	{
		// Token: 0x06000683 RID: 1667 RVA: 0x00030C74 File Offset: 0x0002EE74
		public static void LoadData()
		{
			地图区域.DataSheet = new List<地图区域>();
			string text = CustomClass.GameData目录 + "\\System\\GameMap\\MapArea\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in 序列化类.反序列化(text, typeof(地图区域)))
				{
					地图区域.DataSheet.Add((地图区域)obj);
				}
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000684 RID: 1668 RVA: 0x00005E2B File Offset: 0x0000402B
		public Point 随机坐标
		{
			get
			{
				return this.范围坐标列表[MainProcess.RandomNumber.Next(this.范围坐标列表.Count)];
			}
		}

		// Token: 0x170000BD RID: 189
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

		// Token: 0x06000686 RID: 1670 RVA: 0x000027D8 File Offset: 0x000009D8
		public 地图区域()
		{
			
			
		}

		// Token: 0x0400097F RID: 2431
		public static List<地图区域> DataSheet;

		// Token: 0x04000980 RID: 2432
		public byte 所处地图;

		// Token: 0x04000981 RID: 2433
		public string 所处地名;

		// Token: 0x04000982 RID: 2434
		public Point 所处坐标;

		// Token: 0x04000983 RID: 2435
		public string 区域名字;

		// Token: 0x04000984 RID: 2436
		public int 区域半径;

		// Token: 0x04000985 RID: 2437
		public 地图区域类型 区域类型;

		// Token: 0x04000986 RID: 2438
		public HashSet<Point> 范围坐标;

		// Token: 0x04000987 RID: 2439
		private List<Point> _范围坐标列表;
	}
}
