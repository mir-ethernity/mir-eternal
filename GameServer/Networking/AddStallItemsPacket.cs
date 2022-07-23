using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 157, 长度 = 11, 注释 = "AddStallItemsPacket")]
	public sealed class AddStallItemsPacket : GamePacket
	{
		
		public AddStallItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 放入位置;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 背包类型;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 物品位置;

		
		[WrappingFieldAttribute(下标 = 5, 长度 = 1)]
		public ushort 物品数量;

		
		[WrappingFieldAttribute(下标 = 7, 长度 = 4)]
		public int 物品价格;
	}
}
