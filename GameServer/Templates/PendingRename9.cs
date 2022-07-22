using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	// Token: 0x020002CA RID: 714
	public sealed class 随机属性
	{
		// Token: 0x060006F0 RID: 1776 RVA: 0x00035D44 File Offset: 0x00033F44
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

		// Token: 0x060006F1 RID: 1777 RVA: 0x000027D8 File Offset: 0x000009D8
		public 随机属性()
		{
			
			
		}

		// Token: 0x04000C2A RID: 3114
		public static Dictionary<int, 随机属性> DataSheet;

		// Token: 0x04000C2B RID: 3115
		public GameObjectProperties 对应属性;

		// Token: 0x04000C2C RID: 3116
		public int 属性数值;

		// Token: 0x04000C2D RID: 3117
		public int 属性编号;

		// Token: 0x04000C2E RID: 3118
		public int 战力加成;

		// Token: 0x04000C2F RID: 3119
		public string 属性描述;
	}
}
