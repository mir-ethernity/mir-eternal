using System;
using System.Collections.Generic;

namespace GameServer.Templates
{
	// Token: 0x02000298 RID: 664
	public sealed class C_01_计算命中目标 : 技能任务
	{
		// Token: 0x060006A9 RID: 1705 RVA: 0x00005F01 File Offset: 0x00004101
		public C_01_计算命中目标()
		{
			
			
		}

		// Token: 0x040009F7 RID: 2551
		public bool 清空命中列表;

		// Token: 0x040009F8 RID: 2552
		public bool 技能能否穿墙;

		// Token: 0x040009F9 RID: 2553
		public bool 技能能否招架;

		// Token: 0x040009FA RID: 2554
		public 技能锁定类型 技能锁定方式;

		// Token: 0x040009FB RID: 2555
		public 技能闪避类型 技能闪避方式;

		// Token: 0x040009FC RID: 2556
		public 技能命中反馈 技能命中反馈;

		// Token: 0x040009FD RID: 2557
		public 技能范围类型 技能范围类型;

		// Token: 0x040009FE RID: 2558
		public bool 放空结束技能;

		// Token: 0x040009FF RID: 2559
		public bool 发送中断通知;

		// Token: 0x04000A00 RID: 2560
		public bool 补发释放通知;

		// Token: 0x04000A01 RID: 2561
		public bool 技能命中通知;

		// Token: 0x04000A02 RID: 2562
		public bool 技能扩展通知;

		// Token: 0x04000A03 RID: 2563
		public bool 计算飞行耗时;

		// Token: 0x04000A04 RID: 2564
		public int 单格飞行耗时;

		// Token: 0x04000A05 RID: 2565
		public int 限定命中数量;

		// Token: 0x04000A06 RID: 2566
		public GameObjectType 限定目标类型;

		// Token: 0x04000A07 RID: 2567
		public 游戏对象关系 限定目标关系;

		// Token: 0x04000A08 RID: 2568
		public 指定目标类型 限定特定类型;

		// Token: 0x04000A09 RID: 2569
		public 指定目标类型 攻速提升类型;

		// Token: 0x04000A0A RID: 2570
		public int 攻速提升幅度;

		// Token: 0x04000A0B RID: 2571
		public bool 触发被动技能;

		// Token: 0x04000A0C RID: 2572
		public float 触发被动概率;

		// Token: 0x04000A0D RID: 2573
		public bool 增加技能经验;

		// Token: 0x04000A0E RID: 2574
		public ushort 经验技能编号;

		// Token: 0x04000A0F RID: 2575
		public bool 清除目标状态;

		// Token: 0x04000A10 RID: 2576
		public HashSet<ushort> 清除状态列表;
	}
}
