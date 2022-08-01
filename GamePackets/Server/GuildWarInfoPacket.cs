using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 639, 长度 = 14, 注释 = "GuildWarInfoPacket")]
	public sealed class GuildWarInfoPacket : GamePacket
	{
		
		public GuildWarInfoPacket()
		{
			
			
		}
	}
}
