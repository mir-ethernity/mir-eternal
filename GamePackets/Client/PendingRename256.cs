using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 530, Length = 2, Description = "查询地图路线")]
	public sealed class 查询地图路线 : GamePacket
	{
		
		public 查询地图路线()
		{
			
			
		}
	}
}
