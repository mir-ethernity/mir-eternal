using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 530, 长度 = 2, 注释 = "查询地图路线")]
	public sealed class 查询地图路线 : GamePacket
	{
		
		public 查询地图路线()
		{
			
			
		}
	}
}
