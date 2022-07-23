using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 112, 长度 = 17, 注释 = "购买摊位物品")]
	public sealed class 购买摊位物品 : GamePacket
	{
		
		public 购买摊位物品()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 物品位置;

		
		[WrappingFieldAttribute(下标 = 7, 长度 = 2)]
		public ushort 购买数量;
	}
}
