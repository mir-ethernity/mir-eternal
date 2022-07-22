using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace GameServer.Templates
{
	// Token: 0x0200028B RID: 651
	public sealed class 守卫刷新
	{
		// Token: 0x06000694 RID: 1684 RVA: 0x0003101C File Offset: 0x0002F21C
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

		// Token: 0x06000695 RID: 1685 RVA: 0x000027D8 File Offset: 0x000009D8
		public 守卫刷新()
		{
			
			
		}

		// Token: 0x040009A9 RID: 2473
		public static HashSet<守卫刷新> DataSheet;

		// Token: 0x040009AA RID: 2474
		public ushort 守卫编号;

		// Token: 0x040009AB RID: 2475
		public byte 所处地图;

		// Token: 0x040009AC RID: 2476
		public string 所处地名;

		// Token: 0x040009AD RID: 2477
		public Point 所处坐标;

		// Token: 0x040009AE RID: 2478
		public GameDirection 所处方向;

		// Token: 0x040009AF RID: 2479
		public string 区域名字;
	}
}
