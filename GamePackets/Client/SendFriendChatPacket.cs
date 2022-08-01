using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 526, 长度 = 0, 注释 = "好友聊天")]
	public sealed class SendFriendChatPacket : GamePacket
	{
		
		public SendFriendChatPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 0)]
		public byte[] 字节数据;
	}
}
