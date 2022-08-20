using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 540, Length = 0, Description = "ReceiveChatMessagesPacket(system/private chat/broadcast/voice/guild/team)")]
	public sealed class ReceiveChatMessagesPacket : GamePacket
	{
		
		public ReceiveChatMessagesPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
