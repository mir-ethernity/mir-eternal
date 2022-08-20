using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 615, Length = 6, Description = "查询平台商品")]
	public sealed class 查询平台商品 : GamePacket
	{
		
		public 查询平台商品()
		{
			
			
		}
	}
}
