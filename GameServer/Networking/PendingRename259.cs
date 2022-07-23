using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 615, 长度 = 6, 注释 = "查询平台商品")]
	public sealed class 查询平台商品 : GamePacket
	{
		
		public 查询平台商品()
		{
			
			
		}
	}
}
