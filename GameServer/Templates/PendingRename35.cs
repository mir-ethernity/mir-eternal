using System;

namespace GameServer.Templates
{
	// Token: 0x020002B9 RID: 697
	public class 怪物掉落
	{
		// Token: 0x060006CF RID: 1743 RVA: 0x00035144 File Offset: 0x00033344
		public override string ToString()
		{
			return string.Format("{0} - {1} - {2} - {3}/{4}", new object[]
			{
				this.怪物名字,
				this.物品名字,
				this.掉落概率,
				this.最小数量,
				this.最大数量
			});
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x000027D8 File Offset: 0x000009D8
		public 怪物掉落()
		{
			
			
		}

		// Token: 0x04000B83 RID: 2947
		public string 物品名字;

		// Token: 0x04000B84 RID: 2948
		public string 怪物名字;

		// Token: 0x04000B85 RID: 2949
		public int 掉落概率;

		// Token: 0x04000B86 RID: 2950
		public int 最小数量;

		// Token: 0x04000B87 RID: 2951
		public int 最大数量;
	}
}
