using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 574, Length = 2, Description = "更多GuildEvents")]
	public sealed class 更多GuildEvents : GamePacket
	{
		
		public 更多GuildEvents()
		{
			
			
		}
	}
}
