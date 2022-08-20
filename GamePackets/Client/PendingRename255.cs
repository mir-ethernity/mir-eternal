using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 140, Length = 2, Description = "查询附近队伍")]
	public sealed class 查询附近队伍 : GamePacket
	{
		
		public 查询附近队伍()
		{
			
			
		}
	}
}
