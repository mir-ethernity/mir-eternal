using System;

namespace GameServer.Networking
{
	// Token: 0x0200020B RID: 523
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 601, 长度 = 3, 注释 = "脱离行会应答")]
	public sealed class 脱离行会应答 : GamePacket
	{
		// Token: 0x060002F4 RID: 756 RVA: 0x0000344A File Offset: 0x0000164A
		public 脱离行会应答()
		{
			
			
		}

		// Token: 0x0400076D RID: 1901
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public byte 脱离方式;
	}
}
