using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 641, 长度 = 258, 注释 = "GuildDiplomaticAnnouncementPacket")]
	public sealed class GuildDiplomaticAnnouncementPacket : GamePacket
	{
		
		public GuildDiplomaticAnnouncementPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 256)]
		public byte[] 字节数据;
	}
}
