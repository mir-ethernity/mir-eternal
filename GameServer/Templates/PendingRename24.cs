using System;

namespace GameServer.Templates
{
	// Token: 0x0200029A RID: 666
	public sealed class C_03_计算对象位移 : 技能任务
	{
		// Token: 0x060006AB RID: 1707 RVA: 0x00005F01 File Offset: 0x00004101
		public C_03_计算对象位移()
		{
			
			
		}

		// Token: 0x04000A36 RID: 2614
		public bool 角色自身位移;

		// Token: 0x04000A37 RID: 2615
		public bool 允许超出锚点;

		// Token: 0x04000A38 RID: 2616
		public bool 锚点反向位移;

		// Token: 0x04000A39 RID: 2617
		public bool 位移增加经验;

		// Token: 0x04000A3A RID: 2618
		public bool 多段位移通知;

		// Token: 0x04000A3B RID: 2619
		public bool 能否穿越障碍;

		// Token: 0x04000A3C RID: 2620
		public ushort 自身位移耗时;

		// Token: 0x04000A3D RID: 2621
		public ushort 自身硬直时间;

		// Token: 0x04000A3E RID: 2622
		public byte[] 自身位移次数;

		// Token: 0x04000A3F RID: 2623
		public byte[] 自身位移距离;

		// Token: 0x04000A40 RID: 2624
		public ushort 成功Buff编号;

		// Token: 0x04000A41 RID: 2625
		public float 成功Buff概率;

		// Token: 0x04000A42 RID: 2626
		public ushort 失败Buff编号;

		// Token: 0x04000A43 RID: 2627
		public float 失败Buff概率;

		// Token: 0x04000A44 RID: 2628
		public bool 推动目标位移;

		// Token: 0x04000A45 RID: 2629
		public bool 推动增加经验;

		// Token: 0x04000A46 RID: 2630
		public float 推动目标概率;

		// Token: 0x04000A47 RID: 2631
		public 指定目标类型 推动目标类型;

		// Token: 0x04000A48 RID: 2632
		public byte 连续推动数量;

		// Token: 0x04000A49 RID: 2633
		public ushort 目标位移耗时;

		// Token: 0x04000A4A RID: 2634
		public byte[] 目标位移距离;

		// Token: 0x04000A4B RID: 2635
		public ushort 目标硬直时间;

		// Token: 0x04000A4C RID: 2636
		public ushort 目标位移编号;

		// Token: 0x04000A4D RID: 2637
		public float 位移Buff概率;

		// Token: 0x04000A4E RID: 2638
		public ushort 目标附加编号;

		// Token: 0x04000A4F RID: 2639
		public 指定目标类型 限定附加类型;

		// Token: 0x04000A50 RID: 2640
		public float 附加Buff概率;
	}
}
