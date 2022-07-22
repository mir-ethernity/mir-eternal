using System;

namespace GameServer.Templates
{
	// Token: 0x0200029C RID: 668
	public sealed class C_05_计算目标回复 : 技能任务
	{
		// Token: 0x060006AD RID: 1709 RVA: 0x00005F01 File Offset: 0x00004101
		public C_05_计算目标回复()
		{
			
			
		}

		// Token: 0x04000A5C RID: 2652
		public int[] 体力回复次数;

		// Token: 0x04000A5D RID: 2653
		public float[] 道术叠加次数;

		// Token: 0x04000A5E RID: 2654
		public byte[] 体力回复基数;

		// Token: 0x04000A5F RID: 2655
		public float[] 道术叠加基数;

		// Token: 0x04000A60 RID: 2656
		public int[] 立即回复基数;

		// Token: 0x04000A61 RID: 2657
		public float[] 立即回复系数;

		// Token: 0x04000A62 RID: 2658
		public bool 增加技能经验;

		// Token: 0x04000A63 RID: 2659
		public ushort 经验技能编号;
	}
}
