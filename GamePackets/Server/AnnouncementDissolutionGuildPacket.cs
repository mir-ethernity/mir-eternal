using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 596, 长度 = 2, 注释 = "AnnouncementDissolutionGuildPacket")]
	public sealed class AnnouncementDissolutionGuildPacket : GamePacket
	{
		
		public AnnouncementDissolutionGuildPacket()
		{
			
			
		}
	}
}
