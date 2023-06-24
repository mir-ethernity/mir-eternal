using System;

namespace GameServer.Networking
{
	
	[PacketInfo(Source = PacketSource.Server, Id = 663, Length = 10, Description = "GuildSiegeRegistrationPacket")]
	public sealed class GuildSiegeRegistrationPacket : GamePacket
	{
		[WrappingField(SubScript = 2, Length = 4)]
		public int 行会编号;

        [WrappingField(SubScript = 6, Length = 4)]
        public int U1;
    }
}
