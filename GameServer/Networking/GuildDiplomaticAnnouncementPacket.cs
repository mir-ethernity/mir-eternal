using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 641, 长度 = 258, 注释 = "GuildDiplomaticAnnouncementPacket")]
	public sealed class GuildDiplomaticAnnouncementPacket : GamePacket
	{
		
		public GuildDiplomaticAnnouncementPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 256)]
		public byte[] 字节数据;
	}
}
