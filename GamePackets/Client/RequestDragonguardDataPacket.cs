using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 224, Length = 6, Description = "RequestDragonguardDataPacket")]
	public sealed class RequestDragonguardDataPacket : GamePacket
	{
		
		public RequestDragonguardDataPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
