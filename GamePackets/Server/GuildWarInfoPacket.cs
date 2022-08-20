using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 639, Length = 14, Description = "GuildWarInfoPacket")]
	public sealed class GuildWarInfoPacket : GamePacket
	{
		
		public GuildWarInfoPacket()
		{
			
			
		}
	}
}
