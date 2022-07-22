using System;

namespace GameServer.Templates
{
	// Token: 0x0200028F RID: 655
	public sealed class A_00_触发子类技能 : 技能任务
	{
		// Token: 0x060006A0 RID: 1696 RVA: 0x00005F01 File Offset: 0x00004101
		public A_00_触发子类技能()
		{
			
			
		}

		// Token: 0x040009B7 RID: 2487
		public 技能触发方式 技能触发方式;

		// Token: 0x040009B8 RID: 2488
		public string 触发技能名字;

		// Token: 0x040009B9 RID: 2489
		public string 反手技能名字;

		// Token: 0x040009BA RID: 2490
		public bool 计算触发概率;

		// Token: 0x040009BB RID: 2491
		public bool 计算幸运概率;

		// Token: 0x040009BC RID: 2492
		public float 技能触发概率;

		// Token: 0x040009BD RID: 2493
		public ushort 增加概率Buff;

		// Token: 0x040009BE RID: 2494
		public float Buff增加系数;

		// Token: 0x040009BF RID: 2495
		public bool 验证自身Buff;

		// Token: 0x040009C0 RID: 2496
		public ushort 自身Buff编号;

		// Token: 0x040009C1 RID: 2497
		public bool 触发成功移除;

		// Token: 0x040009C2 RID: 2498
		public bool 验证铭文技能;

		// Token: 0x040009C3 RID: 2499
		public ushort 所需铭文编号;

		// Token: 0x040009C4 RID: 2500
		public bool 同组铭文无效;
	}
}
