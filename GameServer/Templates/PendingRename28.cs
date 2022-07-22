using System;

namespace GameServer.Templates
{
	// Token: 0x0200029E RID: 670
	public sealed class C_07_计算目标瞬移 : 技能任务
	{
		// Token: 0x060006AF RID: 1711 RVA: 0x00005F01 File Offset: 0x00004101
		public C_07_计算目标瞬移()
		{
			
			
		}

		// Token: 0x04000A6C RID: 2668
		public float[] 每级成功概率;

		// Token: 0x04000A6D RID: 2669
		public ushort 瞬移失败提示;

		// Token: 0x04000A6E RID: 2670
		public ushort 失败添加Buff;

		// Token: 0x04000A6F RID: 2671
		public bool 增加技能经验;

		// Token: 0x04000A70 RID: 2672
		public ushort 经验技能编号;
	}
}
