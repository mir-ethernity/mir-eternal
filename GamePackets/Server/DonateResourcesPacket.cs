using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 603, Length = 10, Description = "DonateResourcesPacket")]
	public sealed class DonateResourcesPacket : GamePacket
	{
		
		public DonateResourcesPacket()
		{
			
			
		}
	}
}
