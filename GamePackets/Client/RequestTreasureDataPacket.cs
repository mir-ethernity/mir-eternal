using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 599, Length = 6, Description = "RequestTreasureDataPacket")]
	public sealed class RequestTreasureDataPacket : GamePacket
	{
		
		public RequestTreasureDataPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 数据版本;
	}
}
