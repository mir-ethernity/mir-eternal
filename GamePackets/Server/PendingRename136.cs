using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 129, Length = 6, Description = "物品转移或交换")]
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
