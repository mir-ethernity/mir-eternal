using System;

namespace GameServer.Networking
{
	// Token: 0x020000DD RID: 221
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 526, 长度 = 0, 注释 = "好友聊天")]
	public sealed class SendFriendChatPacket : GamePacket
	{
		// Token: 0x060001C4 RID: 452 RVA: 0x0000344A File Offset: 0x0000164A
		public SendFriendChatPacket()
		{
			
			
		}

		// Token: 0x0400052C RID: 1324
		[WrappingFieldAttribute(下标 = 2, 长度 = 0)]
		public byte[] 字节数据;
	}
}
