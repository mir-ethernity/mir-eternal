using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 179, 长度 = 0, 注释 = "ReceiveChatMessagesNearbyPacket(附近)", Broadcast = true)]
	public sealed class ReceiveChatMessagesNearbyPacket : GamePacket
	{
		
		public ReceiveChatMessagesNearbyPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
