using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 158, Length = 3, Description = "RemoveStallItemsPacket")]
	public sealed class RemoveStallItemsPacket : GamePacket
	{
		
		public RemoveStallItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 取回位置;
	}
}
