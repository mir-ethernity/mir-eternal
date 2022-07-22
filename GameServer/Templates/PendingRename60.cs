using System;

namespace GameServer.Templates
{
	// Token: 0x020002B2 RID: 690
	public enum Buff判定类型
	{
		// Token: 0x04000B17 RID: 2839
		所有技能伤害,
		// Token: 0x04000B18 RID: 2840
		所有物理伤害,
		// Token: 0x04000B19 RID: 2841
		所有魔法伤害,
		// Token: 0x04000B1A RID: 2842
		所有特定伤害 = 4,
		// Token: 0x04000B1B RID: 2843
		来源技能伤害 = 8,
		// Token: 0x04000B1C RID: 2844
		来源物理伤害 = 16,
		// Token: 0x04000B1D RID: 2845
		来源魔法伤害 = 32,
		// Token: 0x04000B1E RID: 2846
		来源特定伤害 = 64
	}
}
