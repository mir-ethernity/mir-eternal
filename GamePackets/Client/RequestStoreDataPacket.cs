using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 65, Length = 6, Description = "RequestStoreDataPacket")]
	public sealed class RequestStoreDataPacket : GamePacket
	{
		
		public RequestStoreDataPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 版本编号;
	}
}
