using System;

namespace GameServer.Templates
{
	// Token: 0x020002A6 RID: 678
	[Flags]
	public enum 指定目标类型
	{
		// Token: 0x04000AA1 RID: 2721
		无 = 0,
		// Token: 0x04000AA2 RID: 2722
		低级目标 = 1,
		// Token: 0x04000AA3 RID: 2723
		带盾法师 = 2,
		// Token: 0x04000AA4 RID: 2724
		低级怪物 = 4,
		// Token: 0x04000AA5 RID: 2725
		低血怪物 = 8,
		// Token: 0x04000AA6 RID: 2726
		普通怪物 = 16,
		// Token: 0x04000AA7 RID: 2727
		所有怪物 = 32,
		// Token: 0x04000AA8 RID: 2728
		不死生物 = 64,
		// Token: 0x04000AA9 RID: 2729
		虫族生物 = 128,
		// Token: 0x04000AAA RID: 2730
		沃玛怪物 = 256,
		// Token: 0x04000AAB RID: 2731
		猪类怪物 = 512,
		// Token: 0x04000AAC RID: 2732
		祖玛怪物 = 1024,
		// Token: 0x04000AAD RID: 2733
		精英怪物 = 2048,
		// Token: 0x04000AAE RID: 2734
		所有宠物 = 4096,
		// Token: 0x04000AAF RID: 2735
		背刺目标 = 8192,
		// Token: 0x04000AB0 RID: 2736
		魔龙怪物 = 16384,
		// Token: 0x04000AB1 RID: 2737
		所有玩家 = 32768
	}
}
