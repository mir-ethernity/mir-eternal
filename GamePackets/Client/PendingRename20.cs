using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 618, 长度 = 9, 注释 = "上架平台商品")]
	public sealed class 上架平台商品 : GamePacket
	{
		
		public 上架平台商品()
		{
			
			
		}
	}
}
