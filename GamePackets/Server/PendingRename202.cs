using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 162, Length = 11, Description = "购买摊位物品")]
	public sealed class 购入摊位物品 : GamePacket
	{
		
		public 购入摊位物品()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 物品位置;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 4)]
		public int 剩余数量;
	}
}
