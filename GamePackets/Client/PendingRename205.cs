using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 600, Length = 42, Description = "购买珍宝商品")]
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
