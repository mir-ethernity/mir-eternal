using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 574, 长度 = 2, 注释 = "更多GuildEvents")]
	public sealed class 更多GuildEvents : GamePacket
	{
		
		public 更多GuildEvents()
		{
			
			
		}
	}
}
