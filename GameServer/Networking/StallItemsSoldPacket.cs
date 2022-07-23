using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 163, 长度 = 11, 注释 = "StallItemsSoldPacket")]
	public sealed class StallItemsSoldPacket : GamePacket
	{
		
		public StallItemsSoldPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 物品位置;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 售出数量;

		
		[WrappingFieldAttribute(下标 = 7, 长度 = 4)]
		public int 售出收益;
	}
}
