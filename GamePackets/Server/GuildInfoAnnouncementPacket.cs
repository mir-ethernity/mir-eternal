using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 587, 长度 = 0, 注释 = "GuildInfoAnnouncementPacket")]
	public sealed class GuildInfoAnnouncementPacket : GamePacket
	{
		
		public GuildInfoAnnouncementPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节数据;
	}
}
