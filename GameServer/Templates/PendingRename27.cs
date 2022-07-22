using System;

namespace GameServer.Templates
{
	// Token: 0x0200029D RID: 669
	public sealed class C_06_计算宠物召唤 : 技能任务
	{
		// Token: 0x060006AE RID: 1710 RVA: 0x00005F01 File Offset: 0x00004101
		public C_06_计算宠物召唤()
		{
			
			
		}

		// Token: 0x04000A64 RID: 2660
		public string 召唤宠物名字;

		// Token: 0x04000A65 RID: 2661
		public bool 怪物召唤同伴;

		// Token: 0x04000A66 RID: 2662
		public byte[] 召唤宠物数量;

		// Token: 0x04000A67 RID: 2663
		public byte[] 宠物等级上限;

		// Token: 0x04000A68 RID: 2664
		public bool 增加技能经验;

		// Token: 0x04000A69 RID: 2665
		public ushort 经验技能编号;

		// Token: 0x04000A6A RID: 2666
		public bool 宠物绑定武器;

		// Token: 0x04000A6B RID: 2667
		public bool 检查技能铭文;
	}
}
