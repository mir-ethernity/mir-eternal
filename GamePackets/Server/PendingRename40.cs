using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 626, Length = 15, Description = "升级建筑公告")]
	public sealed class 升级建筑公告 : GamePacket
	{
		
		public 升级建筑公告()
		{
			
			
		}
	}
}
