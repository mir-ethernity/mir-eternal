using System;

namespace GameServer.Networking
{
	// Token: 0x020000C8 RID: 200
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 217, 长度 = 3, 注释 = "BookMarfaPrivilegesPacket")]
	public sealed class BookMarfaPrivilegesPacket : GamePacket
	{
		// Token: 0x060001AF RID: 431 RVA: 0x0000344A File Offset: 0x0000164A
		public BookMarfaPrivilegesPacket()
		{
			
			
		}

		// Token: 0x04000518 RID: 1304
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 特权类型;
	}
}
