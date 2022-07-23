using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 596, 长度 = 2, 注释 = "AnnouncementDissolutionGuildPacket")]
	public sealed class AnnouncementDissolutionGuildPacket : GamePacket
	{
		
		public AnnouncementDissolutionGuildPacket()
		{
			
			
		}
	}
}
