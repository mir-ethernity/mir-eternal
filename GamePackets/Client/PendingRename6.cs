using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 15, Length = 2, Description = "到达传送门/摆摊点")]
	public sealed class 客户碰触法阵 : GamePacket
	{
		
		public 客户碰触法阵()
		{
			
			
		}
	}
}
