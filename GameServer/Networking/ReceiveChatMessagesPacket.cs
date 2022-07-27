using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 540, 长度 = 0, 注释 = "ReceiveChatMessagesPacket(system/private chat/broadcast/voice/guild/team)")]
	public sealed class ReceiveChatMessagesPacket : GamePacket
	{
		
		public ReceiveChatMessagesPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
