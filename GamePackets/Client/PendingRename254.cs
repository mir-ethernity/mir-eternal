using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 602, Length = 2, Description = "查询出售信息")]
	public sealed class 查询出售信息 : GamePacket
	{
		
		public 查询出售信息()
		{
			
			
		}
	}
}
