using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 536, 长度 = 0, 注释 = "好友聊天")]
	public sealed class SendFriendMessagePacket : GamePacket
	{
		
		public SendFriendMessagePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节数据;
	}
}
