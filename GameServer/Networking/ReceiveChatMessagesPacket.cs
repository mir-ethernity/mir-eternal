using System;

namespace GameServer.Networking
{
	// Token: 0x020001D7 RID: 471
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 540, 长度 = 0, 注释 = "ReceiveChatMessagesPacket(system/private chat/broadcast/voice/guild/team)")]
	public sealed class ReceiveChatMessagesPacket : GamePacket
	{
		// Token: 0x060002C0 RID: 704 RVA: 0x0000344A File Offset: 0x0000164A
		public ReceiveChatMessagesPacket()
		{
			
			
		}

		// Token: 0x0400072D RID: 1837
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节描述;
	}
}
