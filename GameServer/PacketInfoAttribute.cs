using System;

namespace GameServer
{
	// Token: 0x0200005D RID: 93
	[AttributeUsage(AttributeTargets.Class)]
	public class PacketInfoAttribute : Attribute
	{
		// Token: 0x06000117 RID: 279 RVA: 0x000030DE File Offset: 0x000012DE
		public PacketInfoAttribute()
		{
			
			
		}

		// Token: 0x04000479 RID: 1145
		public PacketSource 来源;

		// Token: 0x0400047A RID: 1146
		public ushort 编号;

		// Token: 0x0400047B RID: 1147
		public ushort 长度;

		// Token: 0x0400047C RID: 1148
		public string 注释;
	}
}
