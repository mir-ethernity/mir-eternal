using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 663, Length = 6, Description = "GuildSiegeRegistrationPacket")]
	public sealed class GuildSiegeRegistrationPacket : GamePacket
	{
		
		public GuildSiegeRegistrationPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 行会编号;
	}
}
