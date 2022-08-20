using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 598, Length = 7, Description = "GuildBanAnnouncementPacket")]
	public sealed class GuildBanAnnouncementPacket : GamePacket
	{
		
		public GuildBanAnnouncementPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 禁言状态;
	}
}
