using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 587, Length = 0, Description = "GuildInfoAnnouncementPacket")]
	public sealed class GuildInfoAnnouncementPacket : GamePacket
	{
		
		public GuildInfoAnnouncementPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节数据;
	}
}
