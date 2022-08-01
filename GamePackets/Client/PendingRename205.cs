using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 600, 长度 = 42, 注释 = "购买珍宝商品")]
	public sealed class 购买珍宝商品 : GamePacket
	{
		
		public 购买珍宝商品()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int Id;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 购买数量;
	}
}
