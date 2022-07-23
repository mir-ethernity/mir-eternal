using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 526, 长度 = 0, 注释 = "好友聊天")]
	public sealed class SendFriendChatPacket : GamePacket
	{
		
		public SendFriendChatPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 0)]
		public byte[] 字节数据;
	}
}
