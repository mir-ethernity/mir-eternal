using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	// Token: 0x02000286 RID: 646
	public sealed class 游戏地图
	{
		// Token: 0x06000687 RID: 1671 RVA: 0x00030CD8 File Offset: 0x0002EED8
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

		// Token: 0x06000688 RID: 1672 RVA: 0x00005E6E File Offset: 0x0000406E
		public override string ToString()
		{
			return this.地图名字;
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x000027D8 File Offset: 0x000009D8
		public 游戏地图()
		{
			
			
		}

		// Token: 0x04000988 RID: 2440
		public static Dictionary<byte, 游戏地图> DataSheet;

		// Token: 0x04000989 RID: 2441
		public byte 地图编号;

		// Token: 0x0400098A RID: 2442
		public string 地图名字;

		// Token: 0x0400098B RID: 2443
		public string 地图别名;

		// Token: 0x0400098C RID: 2444
		public string 地形文件;

		// Token: 0x0400098D RID: 2445
		public int 限制人数;

		// Token: 0x0400098E RID: 2446
		public byte 限制等级;

		// Token: 0x0400098F RID: 2447
		public byte 分线数量;

		// Token: 0x04000990 RID: 2448
		public bool 下线传送;

		// Token: 0x04000991 RID: 2449
		public byte 传送地图;

		// Token: 0x04000992 RID: 2450
		public bool 副本地图;
	}
}
