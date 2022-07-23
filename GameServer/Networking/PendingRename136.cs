using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 129, 长度 = 6, 注释 = "物品转移或交换")]
	public sealed class 玩家转移物品 : GamePacket
	{
		
		public 玩家转移物品()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 原有容器;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 原有位置;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 目标容器;

		
		[WrappingFieldAttribute(下标 = 5, 长度 = 1)]
		public byte 目标位置;
	}
}
