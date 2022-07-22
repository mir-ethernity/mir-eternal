using System;

namespace GameServer.Networking
{
	// Token: 0x020001D3 RID: 467
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 536, 长度 = 0, 注释 = "好友聊天")]
	public sealed class SendFriendMessagePacket : GamePacket
	{
		// Token: 0x060002BC RID: 700 RVA: 0x0000344A File Offset: 0x0000164A
		public SendFriendMessagePacket()
		{
			
			
		}

		// Token: 0x0400072A RID: 1834
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节数据;
	}
}
