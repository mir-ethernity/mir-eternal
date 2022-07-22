using System;

namespace GameServer.Networking
{
	// Token: 0x0200022C RID: 556
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 640, 长度 = 10, 注释 = "DisarmHostileListPacket")]
	public sealed class DisarmHostileListPacket : GamePacket
	{
		// Token: 0x06000315 RID: 789 RVA: 0x0000344A File Offset: 0x0000164A
		public DisarmHostileListPacket()
		{
			
			
		}

		// Token: 0x04000786 RID: 1926
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 申请类型;

		// Token: 0x04000787 RID: 1927
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 行会编号;
	}
}
