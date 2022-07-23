using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 663, 长度 = 6, 注释 = "GuildSiegeRegistrationPacket")]
	public sealed class GuildSiegeRegistrationPacket : GamePacket
	{
		
		public GuildSiegeRegistrationPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 行会编号;
	}
}
