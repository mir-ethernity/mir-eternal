using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 179, Length = 0, Description = "ReceiveChatMessagesNearbyPacket(附近)", Broadcast = true)]
	public sealed class ReceiveChatMessagesNearbyPacket : GamePacket
	{
		
		public ReceiveChatMessagesNearbyPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
