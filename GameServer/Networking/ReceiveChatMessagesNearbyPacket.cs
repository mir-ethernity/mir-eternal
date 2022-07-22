using System;

namespace GameServer.Networking
{
	// Token: 0x02000197 RID: 407
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 179, 长度 = 0, 注释 = "ReceiveChatMessagesNearbyPacket(附近)")]
	public sealed class ReceiveChatMessagesNearbyPacket : GamePacket
	{
		// Token: 0x06000280 RID: 640 RVA: 0x0000344A File Offset: 0x0000164A
		public ReceiveChatMessagesNearbyPacket()
		{
			
			
		}

		// Token: 0x040006B6 RID: 1718
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节描述;
	}
}
