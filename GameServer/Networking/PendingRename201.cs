using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 658, 长度 = 10, 注释 = "购买珍宝商品")]
	public sealed class 购入珍宝商品 : GamePacket
	{
		
		public 购入珍宝商品()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 物品编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 购买数量;
	}
}
