using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 587, 长度 = 0, 注释 = "GuildInfoAnnouncementPacket")]
	public sealed class GuildInfoAnnouncementPacket : GamePacket
	{
		
		public GuildInfoAnnouncementPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节数据;
	}
}
