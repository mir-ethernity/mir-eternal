using System;

namespace GameServer.Templates
{
	// Token: 0x020002A7 RID: 679
	[Flags]
	public enum 技能命中反馈
	{
		// Token: 0x04000AB3 RID: 2739
		正常 = 0,
		// Token: 0x04000AB4 RID: 2740
		喷血 = 1,
		// Token: 0x04000AB5 RID: 2741
		格挡 = 2,
		// Token: 0x04000AB6 RID: 2742
		闪避 = 4,
		// Token: 0x04000AB7 RID: 2743
		招架 = 8,
		// Token: 0x04000AB8 RID: 2744
		丢失 = 16,
		// Token: 0x04000AB9 RID: 2745
		后仰 = 32,
		// Token: 0x04000ABA RID: 2746
		免疫 = 64,
		// Token: 0x04000ABB RID: 2747
		死亡 = 128,
		// Token: 0x04000ABC RID: 2748
		特效 = 256
	}
}
