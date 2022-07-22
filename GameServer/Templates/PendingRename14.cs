using System;

namespace GameServer.Templates
{
	// Token: 0x02000290 RID: 656
	public sealed class A_01_触发对象Buff : 技能任务
	{
		// Token: 0x060006A1 RID: 1697 RVA: 0x00005F01 File Offset: 0x00004101
		public A_01_触发对象Buff()
		{
			
			
		}

		// Token: 0x040009C5 RID: 2501
		public bool 角色自身添加;

		// Token: 0x040009C6 RID: 2502
		public ushort 触发Buff编号;

		// Token: 0x040009C7 RID: 2503
		public ushort 伴生Buff编号;

		// Token: 0x040009C8 RID: 2504
		public float Buff触发概率;

		// Token: 0x040009C9 RID: 2505
		public bool 验证铭文技能;

		// Token: 0x040009CA RID: 2506
		public ushort 所需铭文编号;

		// Token: 0x040009CB RID: 2507
		public bool 同组铭文无效;

		// Token: 0x040009CC RID: 2508
		public bool 验证自身Buff;

		// Token: 0x040009CD RID: 2509
		public ushort 自身Buff编号;

		// Token: 0x040009CE RID: 2510
		public bool 触发成功移除;

		// Token: 0x040009CF RID: 2511
		public bool 移除伴生Buff;

		// Token: 0x040009D0 RID: 2512
		public ushort 移除伴生编号;

		// Token: 0x040009D1 RID: 2513
		public bool 验证分组Buff;

		// Token: 0x040009D2 RID: 2514
		public ushort Buff分组编号;

		// Token: 0x040009D3 RID: 2515
		public bool 验证目标Buff;

		// Token: 0x040009D4 RID: 2516
		public ushort 目标Buff编号;

		// Token: 0x040009D5 RID: 2517
		public byte 所需Buff层数;

		// Token: 0x040009D6 RID: 2518
		public bool 验证目标类型;

		// Token: 0x040009D7 RID: 2519
		public 指定目标类型 所需目标类型;

		// Token: 0x040009D8 RID: 2520
		public bool 增加技能经验;

		// Token: 0x040009D9 RID: 2521
		public ushort 经验技能编号;
	}
}
