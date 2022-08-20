using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 637, Length = 7, Description = "GuildWarProclamationPacket")]
	public sealed class GuildWarProclamationPacket : GamePacket
	{
		
		public GuildWarProclamationPacket()
		{
			
			
		}
	}
}
