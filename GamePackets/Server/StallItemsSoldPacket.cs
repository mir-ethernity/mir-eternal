using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 163, Length = 11, Description = "StallItemsSoldPacket")]
	public sealed class StallItemsSoldPacket : GamePacket
	{
		
		public StallItemsSoldPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 物品位置;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int 售出数量;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 4)]
		public int 售出收益;
	}
}
