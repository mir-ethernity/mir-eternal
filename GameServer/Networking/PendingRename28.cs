using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 55, 长度 = 4, 注释 = "商店特修单件")]
	public sealed class 商店特修单件 : GamePacket
	{
		
		public 商店特修单件()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 物品容器;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 物品位置;
	}
}
