using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 216, Length = 0, Description = "PutInTradeItemsPacket")]
	public sealed class PutInTradeItemsPacket : GamePacket
	{
		
		public PutInTradeItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 1)]
		public byte 放入位置;

		
		[WrappingFieldAttribute(SubScript = 9, Length = 1)]
		public byte 放入物品;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 0)]
		public byte[] 物品描述;
	}
}
