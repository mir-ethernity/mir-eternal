using System;

namespace GameServer.Networking
{
	// Token: 0x020000A5 RID: 165
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 131, 长度 = 0, 注释 = "SendChatMessagePacket(附近|广播|传音)")]
	public sealed class SendChatMessagePacket : GamePacket
	{
		// Token: 0x0600018C RID: 396 RVA: 0x0000344A File Offset: 0x0000164A
		public SendChatMessagePacket()
		{
			
			
		}

		// Token: 0x040004F7 RID: 1271
		[WrappingFieldAttribute(下标 = 2, 长度 = 0)]
		public byte[] 字节数据;
	}
}
