using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 567, Length = 6, Description = "TransferPresidentPositionPacket")]
	public sealed class TransferPresidentPositionPacket : GamePacket
	{
		
		public TransferPresidentPositionPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
