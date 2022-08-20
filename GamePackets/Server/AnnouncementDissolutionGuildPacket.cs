using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 596, Length = 2, Description = "AnnouncementDissolutionGuildPacket")]
	public sealed class AnnouncementDissolutionGuildPacket : GamePacket
	{
		
		public AnnouncementDissolutionGuildPacket()
		{
			
			
		}
	}
}
