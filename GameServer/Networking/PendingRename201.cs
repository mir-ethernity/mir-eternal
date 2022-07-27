using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 658, 长度 = 10, 注释 = "购买珍宝商品")]
	public sealed class 购入珍宝商品 : GamePacket
	{
		
		public 购入珍宝商品()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int Id;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 购买数量;
	}
}
