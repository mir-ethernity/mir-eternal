using System;

namespace GameServer.Templates
{
	// Token: 0x02000295 RID: 661
	public sealed class B_03_前摇结束通知 : 技能任务
	{
		// Token: 0x060006A6 RID: 1702 RVA: 0x00005F01 File Offset: 0x00004101
		public B_03_前摇结束通知()
		{
			
			
		}

		// Token: 0x040009EC RID: 2540
		public bool 发送结束通知;

		// Token: 0x040009ED RID: 2541
		public bool 计算攻速缩减;

		// Token: 0x040009EE RID: 2542
		public int 角色硬直时间;

		// Token: 0x040009EF RID: 2543
		public int 禁止行走时间;

		// Token: 0x040009F0 RID: 2544
		public int 禁止奔跑时间;

		// Token: 0x040009F1 RID: 2545
		public bool 解除技能陷阱;
	}
}
