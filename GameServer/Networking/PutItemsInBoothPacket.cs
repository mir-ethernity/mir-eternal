using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 107, 长度 = 11, 注释 = "PutItemsInBoothPacket")]
	public sealed class PutItemsInBoothPacket : GamePacket
	{
		
		public PutItemsInBoothPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 放入位置;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 物品容器;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 物品位置;

		
		[WrappingFieldAttribute(下标 = 5, 长度 = 2)]
		public ushort 物品数量;

		
		[WrappingFieldAttribute(下标 = 7, 长度 = 1)]
		public int 物品价格;
	}
}
