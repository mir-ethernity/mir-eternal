using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	// Token: 0x020002C7 RID: 711
	public sealed class 游戏称号
	{
		// Token: 0x060006EB RID: 1771 RVA: 0x00035A6C File Offset: 0x00033C6C
		public static void LoadData()
		{
			游戏称号.DataSheet = new Dictionary<byte, 游戏称号>();
			string text = CustomClass.GameData目录 + "\\System\\Items\\GameTitle\\";
			if (Directory.Exists(text))
			{
				object[] array = 序列化类.反序列化(text, typeof(游戏称号));
				for (int i = 0; i < array.Length; i++)
				{
					游戏称号 游戏称号 = array[i] as 游戏称号;
					游戏称号.DataSheet.Add(游戏称号.称号编号, 游戏称号);
				}
			}
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x000027D8 File Offset: 0x000009D8
		public 游戏称号()
		{
			
			
		}

		// Token: 0x04000C23 RID: 3107
		public static Dictionary<byte, 游戏称号> DataSheet;

		// Token: 0x04000C24 RID: 3108
		public byte 称号编号;

		// Token: 0x04000C25 RID: 3109
		public string 称号名字;

		// Token: 0x04000C26 RID: 3110
		public int 称号战力;

		// Token: 0x04000C27 RID: 3111
		public int 有效时间;

		// Token: 0x04000C28 RID: 3112
		public Dictionary<GameObjectProperties, int> 称号属性;
	}
}
