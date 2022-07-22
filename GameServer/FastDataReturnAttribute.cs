using System;

namespace GameServer
{
	// Token: 0x0200005C RID: 92
	[AttributeUsage(AttributeTargets.Class)]
	public class FastDataReturnAttribute : Attribute
	{
		// Token: 0x06000116 RID: 278 RVA: 0x000030DE File Offset: 0x000012DE
		public FastDataReturnAttribute()
		{
			
			
		}

		// Token: 0x04000478 RID: 1144
		public string 检索字段;
	}
}
