using System;

namespace GameServer
{
	// Token: 0x0200005E RID: 94
	[AttributeUsage(AttributeTargets.Field)]
	public class WrappingFieldAttribute : Attribute
	{
		// Token: 0x06000118 RID: 280 RVA: 0x000030DE File Offset: 0x000012DE
		public WrappingFieldAttribute()
		{
			
			
		}

		// Token: 0x0400047D RID: 1149
		public ushort 下标;

		// Token: 0x0400047E RID: 1150
		public ushort 长度;

		// Token: 0x0400047F RID: 1151
		public bool 反向;
	}
}
