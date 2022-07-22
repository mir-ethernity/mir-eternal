using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace GameServer.Templates
{
	// Token: 0x02000282 RID: 642
	public class 传送法阵
	{
		// Token: 0x0600067E RID: 1662 RVA: 0x00030AC4 File Offset: 0x0002ECC4
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

		// Token: 0x0600067F RID: 1663 RVA: 0x000027D8 File Offset: 0x000009D8
		public 传送法阵()
		{
			
			
		}

		// Token: 0x04000931 RID: 2353
		public static List<传送法阵> DataSheet;

		// Token: 0x04000932 RID: 2354
		public byte 法阵编号;

		// Token: 0x04000933 RID: 2355
		public byte 所处地图;

		// Token: 0x04000934 RID: 2356
		public byte 跳转地图;

		// Token: 0x04000935 RID: 2357
		public string 法阵名字;

		// Token: 0x04000936 RID: 2358
		public string 所处地名;

		// Token: 0x04000937 RID: 2359
		public string 跳转地名;

		// Token: 0x04000938 RID: 2360
		public string 所处别名;

		// Token: 0x04000939 RID: 2361
		public string 跳转别名;

		// Token: 0x0400093A RID: 2362
		public Point 所处坐标;

		// Token: 0x0400093B RID: 2363
		public Point 跳转坐标;
	}
}
