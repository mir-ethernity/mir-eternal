using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 107, 长度 = 11, 注释 = "PutItemsInBoothPacket")]
	public sealed class PutItemsInBoothPacket : GamePacket
	{
		
		public PutItemsInBoothPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 放入位置;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 物品容器;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 物品位置;

		
		[WrappingFieldAttribute(SubScript = 5, Length = 2)]
		public ushort 物品数量;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 1)]
		public int 物品价格;
	}
}
