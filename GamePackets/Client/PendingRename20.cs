using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 618, Length = 9, Description = "上架平台商品")]
	public sealed class 上架平台商品 : GamePacket
	{
		
		public 上架平台商品()
		{
			
			
		}
	}
}
