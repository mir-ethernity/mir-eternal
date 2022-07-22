using System;

namespace GameServer.Templates
{
	// Token: 0x02000293 RID: 659
	public sealed class B_01_技能释放通知 : 技能任务
	{
		// Token: 0x060006A4 RID: 1700 RVA: 0x00005F01 File Offset: 0x00004101
		public B_01_技能释放通知()
		{
			
			
		}

		// Token: 0x040009E0 RID: 2528
		public bool 发送释放通知;

		// Token: 0x040009E1 RID: 2529
		public bool 移除技能标记;

		// Token: 0x040009E2 RID: 2530
		public bool 调整角色朝向;

		// Token: 0x040009E3 RID: 2531
		public int 自身冷却时间;

		// Token: 0x040009E4 RID: 2532
		public bool Buff增加冷却;

		// Token: 0x040009E5 RID: 2533
		public ushort 增加冷却Buff;

		// Token: 0x040009E6 RID: 2534
		public int 冷却增加时间;

		// Token: 0x040009E7 RID: 2535
		public int 分组冷却时间;

		// Token: 0x040009E8 RID: 2536
		public int 角色忙绿时间;
	}
}
