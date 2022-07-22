using System;

namespace GameServer.Templates
{
	// Token: 0x020002AC RID: 684
	public enum 技能触发方式
	{
		// Token: 0x04000AED RID: 2797
		原点位置绝对触发,
		// Token: 0x04000AEE RID: 2798
		锚点位置绝对触发,
		// Token: 0x04000AEF RID: 2799
		刺杀位置绝对触发,
		// Token: 0x04000AF0 RID: 2800
		目标命中绝对触发,
		// Token: 0x04000AF1 RID: 2801
		怪物死亡绝对触发,
		// Token: 0x04000AF2 RID: 2802
		怪物死亡换位触发,
		// Token: 0x04000AF3 RID: 2803
		怪物命中绝对触发,
		// Token: 0x04000AF4 RID: 2804
		怪物命中概率触发,
		// Token: 0x04000AF5 RID: 2805
		无目标锚点位触发,
		// Token: 0x04000AF6 RID: 2806
		目标位置绝对触发,
		// Token: 0x04000AF7 RID: 2807
		正手反手随机触发,
		// Token: 0x04000AF8 RID: 2808
		目标死亡绝对触发,
		// Token: 0x04000AF9 RID: 2809
		目标闪避绝对触发
	}
}
