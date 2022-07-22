using System;

namespace GameServer.Templates
{
	// Token: 0x020002A5 RID: 677
	[Flags]
	public enum 游戏对象状态
	{
		// Token: 0x04000A93 RID: 2707
		正常状态 = 0,
		// Token: 0x04000A94 RID: 2708
		硬直状态 = 1,
		// Token: 0x04000A95 RID: 2709
		忙绿状态 = 2,
		// Token: 0x04000A96 RID: 2710
		中毒状态 = 4,
		// Token: 0x04000A97 RID: 2711
		残废状态 = 8,
		// Token: 0x04000A98 RID: 2712
		定身状态 = 16,
		// Token: 0x04000A99 RID: 2713
		麻痹状态 = 32,
		// Token: 0x04000A9A RID: 2714
		霸体状态 = 64,
		// Token: 0x04000A9B RID: 2715
		无敌状态 = 128,
		// Token: 0x04000A9C RID: 2716
		隐身状态 = 256,
		// Token: 0x04000A9D RID: 2717
		潜行状态 = 512,
		// Token: 0x04000A9E RID: 2718
		失神状态 = 1024,
		// Token: 0x04000A9F RID: 2719
		暴露状态 = 2048
	}
}
