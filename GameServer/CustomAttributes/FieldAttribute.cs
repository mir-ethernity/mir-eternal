using System;

namespace GameServer
{
	// Token: 0x02000003 RID: 3
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class FieldAttribute : Attribute
	{
		// Token: 0x06000001 RID: 1 RVA: 0x000027C4 File Offset: 0x000009C4
		public FieldAttribute(int 排序 = 0)
		{
			
			
			this.排序 = 排序;
		}

		// Token: 0x04000001 RID: 1
		public int 排序;
	}
}
