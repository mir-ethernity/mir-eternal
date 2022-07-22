using System;
using System.Collections.Generic;

namespace GameServer.Templates
{
	// Token: 0x02000299 RID: 665
	public sealed class C_02_计算目标伤害 : 技能任务
	{
		// Token: 0x060006AA RID: 1706 RVA: 0x00005F01 File Offset: 0x00004101
		public C_02_计算目标伤害()
		{
			
			
		}

		// Token: 0x04000A11 RID: 2577
		public bool 点爆命中目标;

		// Token: 0x04000A12 RID: 2578
		public ushort 点爆标记编号;

		// Token: 0x04000A13 RID: 2579
		public byte 点爆需要层数;

		// Token: 0x04000A14 RID: 2580
		public bool 失败添加层数;

		// Token: 0x04000A15 RID: 2581
		public int[] 技能伤害基数;

		// Token: 0x04000A16 RID: 2582
		public float[] 技能伤害系数;

		// Token: 0x04000A17 RID: 2583
		public 技能伤害类型 技能伤害类型;

		// Token: 0x04000A18 RID: 2584
		public 指定目标类型 技能增伤类型;

		// Token: 0x04000A19 RID: 2585
		public int 技能增伤基数;

		// Token: 0x04000A1A RID: 2586
		public float 技能增伤系数;

		// Token: 0x04000A1B RID: 2587
		public bool 数量衰减伤害;

		// Token: 0x04000A1C RID: 2588
		public float 伤害衰减系数;

		// Token: 0x04000A1D RID: 2589
		public float 伤害衰减下限;

		// Token: 0x04000A1E RID: 2590
		public 指定目标类型 技能斩杀类型;

		// Token: 0x04000A1F RID: 2591
		public float 技能斩杀概率;

		// Token: 0x04000A20 RID: 2592
		public float 技能破防概率;

		// Token: 0x04000A21 RID: 2593
		public int 技能破防基数;

		// Token: 0x04000A22 RID: 2594
		public float 技能破防系数;

		// Token: 0x04000A23 RID: 2595
		public int 目标硬直时间;

		// Token: 0x04000A24 RID: 2596
		public bool 目标死亡回复;

		// Token: 0x04000A25 RID: 2597
		public 指定目标类型 回复限定类型;

		// Token: 0x04000A26 RID: 2598
		public int 体力回复基数;

		// Token: 0x04000A27 RID: 2599
		public bool 等级差减回复;

		// Token: 0x04000A28 RID: 2600
		public int 减回复等级差;

		// Token: 0x04000A29 RID: 2601
		public int 零回复等级差;

		// Token: 0x04000A2A RID: 2602
		public bool 增加宠物仇恨;

		// Token: 0x04000A2B RID: 2603
		public bool 击杀减少冷却;

		// Token: 0x04000A2C RID: 2604
		public bool 命中减少冷却;

		// Token: 0x04000A2D RID: 2605
		public 指定目标类型 冷却减少类型;

		// Token: 0x04000A2E RID: 2606
		public ushort 冷却减少技能;

		// Token: 0x04000A2F RID: 2607
		public byte 冷却减少分组;

		// Token: 0x04000A30 RID: 2608
		public ushort 冷却减少时间;

		// Token: 0x04000A31 RID: 2609
		public bool 扣除武器持久;

		// Token: 0x04000A32 RID: 2610
		public bool 增加技能经验;

		// Token: 0x04000A33 RID: 2611
		public ushort 经验技能编号;

		// Token: 0x04000A34 RID: 2612
		public bool 清除目标状态;

		// Token: 0x04000A35 RID: 2613
		public HashSet<ushort> 清除状态列表;
	}
}
