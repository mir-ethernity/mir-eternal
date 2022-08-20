using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 572, Length = 6, Description = "ApprenticeSuccessfullyPacket")]
	public sealed class ApprenticeSuccessfullyPacket : GamePacket
	{
		
		public ApprenticeSuccessfullyPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
