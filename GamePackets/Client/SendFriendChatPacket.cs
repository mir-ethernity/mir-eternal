using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 526, Length = 0, Description = "好友聊天")]
	public sealed class SendFriendChatPacket : GamePacket
	{
		
		public SendFriendChatPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 0)]
		public byte[] 字节数据;
	}
}
