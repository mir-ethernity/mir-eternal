using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 536, 长度 = 0, 注释 = "好友聊天")]
	public sealed class SendFriendMessagePacket : GamePacket
	{
		
		public SendFriendMessagePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节数据;
	}
}
