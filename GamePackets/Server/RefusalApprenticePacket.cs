using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 553, Length = 6, Description = "RefusalApprenticePacket")]
	public sealed class RefusalApprenticePacket : GamePacket
	{
		
		public RefusalApprenticePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
