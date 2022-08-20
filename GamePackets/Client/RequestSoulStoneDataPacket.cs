using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 231, Length = 6, Description = "RequestSoulStoneDataPacket")]
	public sealed class RequestSoulStoneDataPacket : GamePacket
	{
		
		public RequestSoulStoneDataPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
