using System;

namespace GameServer.Networking
{
	// Token: 0x020000C9 RID: 201
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 224, 长度 = 6, 注释 = "RequestDragonguardDataPacket")]
	public sealed class RequestDragonguardDataPacket : GamePacket
	{
		// Token: 0x060001B0 RID: 432 RVA: 0x0000344A File Offset: 0x0000164A
		public RequestDragonguardDataPacket()
		{
			
			
		}

		// Token: 0x04000519 RID: 1305
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
