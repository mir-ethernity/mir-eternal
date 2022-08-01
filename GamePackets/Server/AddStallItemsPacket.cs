using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 157, 长度 = 11, 注释 = "AddStallItemsPacket")]
	public sealed class AddStallItemsPacket : GamePacket
	{
		
		public AddStallItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 放入位置;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 背包类型;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 物品位置;

		
		[WrappingFieldAttribute(SubScript = 5, Length = 1)]
		public ushort 物品数量;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 4)]
		public int 物品价格;
	}
}
