using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	// Token: 0x020002C4 RID: 708
	public sealed class 地图守卫
	{
		// Token: 0x060006E4 RID: 1764 RVA: 0x000358D0 File Offset: 0x00033AD0
		public static void LoadData()
		{
			地图守卫.DataSheet = new Dictionary<ushort, 地图守卫>();
			string text = CustomClass.GameData目录 + "\\System\\Npc\\Guards\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in 序列化类.反序列化(text, typeof(地图守卫)))
				{
					地图守卫.DataSheet.Add(((地图守卫)obj).守卫编号, (地图守卫)obj);
				}
			}
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x000027D8 File Offset: 0x000009D8
		public 地图守卫()
		{
			
			
		}

		// Token: 0x04000BD8 RID: 3032
		public static Dictionary<ushort, 地图守卫> DataSheet;

		// Token: 0x04000BD9 RID: 3033
		public string 守卫名字;

		// Token: 0x04000BDA RID: 3034
		public ushort 守卫编号;

		// Token: 0x04000BDB RID: 3035
		public byte 守卫等级;

		// Token: 0x04000BDC RID: 3036
		public bool 虚无状态;

		// Token: 0x04000BDD RID: 3037
		public bool 能否受伤;

		// Token: 0x04000BDE RID: 3038
		public int 尸体保留;

		// Token: 0x04000BDF RID: 3039
		public int 复活间隔;

		// Token: 0x04000BE0 RID: 3040
		public bool 主动攻击;

		// Token: 0x04000BE1 RID: 3041
		public byte 仇恨范围;

		// Token: 0x04000BE2 RID: 3042
		public string 普攻技能;

		// Token: 0x04000BE3 RID: 3043
		public int 商店编号;

		// Token: 0x04000BE4 RID: 3044
		public string 界面代码;
	}
}
