using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 55, 长度 = 4, 注释 = "商店特修单件")]
	public sealed class 商店特修单件 : GamePacket
	{
		
		public 商店特修单件()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 物品容器;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 物品位置;
	}
}
