using System;

namespace GameServer.Templates
{
	// Token: 0x020002B0 RID: 688
	[Flags]
	public enum Buff效果类型
	{
		// Token: 0x04000B09 RID: 2825
		技能标志 = 0,
		// Token: 0x04000B0A RID: 2826
		状态标志 = 1,
		// Token: 0x04000B0B RID: 2827
		造成伤害 = 2,
		// Token: 0x04000B0C RID: 2828
		属性增减 = 4,
		// Token: 0x04000B0D RID: 2829
		伤害增减 = 8,
		// Token: 0x04000B0E RID: 2830
		创建陷阱 = 16,
		// Token: 0x04000B0F RID: 2831
		生命回复 = 32,
		// Token: 0x04000B10 RID: 2832
		诱惑提升 = 64
	}
}
