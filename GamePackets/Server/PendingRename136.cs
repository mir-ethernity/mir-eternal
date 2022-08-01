using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 129, 长度 = 6, 注释 = "物品转移或交换")]
	public sealed class 玩家转移物品 : GamePacket
	{
		
		public 玩家转移物品()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 原有容器;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 原有位置;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 目标容器;

		
		[WrappingFieldAttribute(SubScript = 5, Length = 1)]
		public byte 目标位置;
	}
}
