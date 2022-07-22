using System;

namespace GameServer.Templates
{
	// Token: 0x020002C6 RID: 710
	public class 游戏装备 : 游戏物品
	{
		// Token: 0x060006EA RID: 1770 RVA: 0x000060AE File Offset: 0x000042AE
		public 游戏装备()
		{
			
			
		}

		// Token: 0x04000BFD RID: 3069
		public bool 死亡销毁;

		// Token: 0x04000BFE RID: 3070
		public bool 禁止卸下;

		// Token: 0x04000BFF RID: 3071
		public bool 能否修理;

		// Token: 0x04000C00 RID: 3072
		public int 修理花费;

		// Token: 0x04000C01 RID: 3073
		public int 特修花费;

		// Token: 0x04000C02 RID: 3074
		public int 需要攻击;

		// Token: 0x04000C03 RID: 3075
		public int 需要魔法;

		// Token: 0x04000C04 RID: 3076
		public int 需要道术;

		// Token: 0x04000C05 RID: 3077
		public int 需要刺术;

		// Token: 0x04000C06 RID: 3078
		public int 需要弓术;

		// Token: 0x04000C07 RID: 3079
		public int 基础战力;

		// Token: 0x04000C08 RID: 3080
		public int 最小攻击;

		// Token: 0x04000C09 RID: 3081
		public int 最大攻击;

		// Token: 0x04000C0A RID: 3082
		public int 最小魔法;

		// Token: 0x04000C0B RID: 3083
		public int 最大魔法;

		// Token: 0x04000C0C RID: 3084
		public int 最小道术;

		// Token: 0x04000C0D RID: 3085
		public int 最大道术;

		// Token: 0x04000C0E RID: 3086
		public int 最小刺术;

		// Token: 0x04000C0F RID: 3087
		public int 最大刺术;

		// Token: 0x04000C10 RID: 3088
		public int 最小弓术;

		// Token: 0x04000C11 RID: 3089
		public int 最大弓术;

		// Token: 0x04000C12 RID: 3090
		public int 最小防御;

		// Token: 0x04000C13 RID: 3091
		public int 最大防御;

		// Token: 0x04000C14 RID: 3092
		public int 最小魔防;

		// Token: 0x04000C15 RID: 3093
		public int 最大魔防;

		// Token: 0x04000C16 RID: 3094
		public int 最大体力;

		// Token: 0x04000C17 RID: 3095
		public int 最大魔力;

		// Token: 0x04000C18 RID: 3096
		public int 物理准确;

		// Token: 0x04000C19 RID: 3097
		public int 物理敏捷;

		// Token: 0x04000C1A RID: 3098
		public int 攻击速度;

		// Token: 0x04000C1B RID: 3099
		public int 魔法闪避;

		// Token: 0x04000C1C RID: 3100
		public int 打孔上限;

		// Token: 0x04000C1D RID: 3101
		public int 一孔花费;

		// Token: 0x04000C1E RID: 3102
		public int 二孔花费;

		// Token: 0x04000C1F RID: 3103
		public int 重铸灵石;

		// Token: 0x04000C20 RID: 3104
		public int 灵石数量;

		// Token: 0x04000C21 RID: 3105
		public int 金币数量;

		// Token: 0x04000C22 RID: 3106
		public GameEquipmentSet 装备套装;
	}
}
