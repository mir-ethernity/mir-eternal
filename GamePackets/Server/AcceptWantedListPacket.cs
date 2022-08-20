using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 314, Length = 0, Description = "AcceptWantedListPacket")]
	public sealed class AcceptWantedListPacket : GamePacket
	{
		
		public AcceptWantedListPacket()
		{
			
			
		}
	}
}
