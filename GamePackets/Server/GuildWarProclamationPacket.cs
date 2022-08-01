using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 637, 长度 = 7, 注释 = "GuildWarProclamationPacket")]
	public sealed class GuildWarProclamationPacket : GamePacket
	{
		
		public GuildWarProclamationPacket()
		{
			
			
		}
	}
}
