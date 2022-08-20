using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 641, Length = 258, Description = "GuildDiplomaticAnnouncementPacket")]
	public sealed class GuildDiplomaticAnnouncementPacket : GamePacket
	{
		
		public GuildDiplomaticAnnouncementPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 256)]
		public byte[] 字节数据;
	}
}
