using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 571, Length = 6, Description = "CongratsToApprenticeForAnsweringPacket")]
	public sealed class CongratsToApprenticeForAnsweringPacket : GamePacket
	{
		
		public CongratsToApprenticeForAnsweringPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 徒弟编号;
	}
}
