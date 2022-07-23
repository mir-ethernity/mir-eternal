using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 600, 长度 = 42, 注释 = "购买珍宝商品")]
	public sealed class 购买珍宝商品 : GamePacket
	{
		
		public 购买珍宝商品()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int Id;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 购买数量;
	}
}
