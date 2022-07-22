using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace GameServer.Templates
{
	// Token: 0x02000287 RID: 647
	public class 怪物刷新
	{
		// Token: 0x0600068A RID: 1674 RVA: 0x00030D48 File Offset: 0x0002EF48
		public static void LoadData()
		{
			怪物刷新.DataSheet = new HashSet<怪物刷新>();
			string text = CustomClass.GameData目录 + "\\System\\GameMap\\MonsterRefresh\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in 序列化类.反序列化(text, typeof(怪物刷新)))
				{
					怪物刷新.DataSheet.Add((怪物刷新)obj);
				}
			}
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x000027D8 File Offset: 0x000009D8
		public 怪物刷新()
		{
			
			
		}

		// Token: 0x04000993 RID: 2451
		public static HashSet<怪物刷新> DataSheet;

		// Token: 0x04000994 RID: 2452
		public byte 所处地图;

		// Token: 0x04000995 RID: 2453
		public string 所处地名;

		// Token: 0x04000996 RID: 2454
		public Point 所处坐标;

		// Token: 0x04000997 RID: 2455
		public string 区域名字;

		// Token: 0x04000998 RID: 2456
		public int 区域半径;

		// Token: 0x04000999 RID: 2457
		public 刷新信息[] 刷新列表;

		// Token: 0x0400099A RID: 2458
		public HashSet<Point> 范围坐标;
	}
}
