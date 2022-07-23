using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 150, 长度 = 6, 注释 = "玩家放入物品")]
	public sealed class 玩家放入物品 : GamePacket
	{
		
		public 玩家放入物品()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 放入位置;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 放入物品;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 物品容器;

		
		[WrappingFieldAttribute(下标 = 5, 长度 = 1)]
		public byte 物品位置;
	}
}
