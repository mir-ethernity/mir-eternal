using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 15, 长度 = 2, 注释 = "到达传送门/摆摊点")]
	public sealed class 客户碰触法阵 : GamePacket
	{
		
		public 客户碰触法阵()
		{
			
			
		}
	}
}
