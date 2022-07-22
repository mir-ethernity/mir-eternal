using System;

namespace GameServer.Networking
{
	// Token: 0x0200018F RID: 399
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 157, 长度 = 11, 注释 = "AddStallItemsPacket")]
	public sealed class AddStallItemsPacket : GamePacket
	{
		// Token: 0x06000278 RID: 632 RVA: 0x0000344A File Offset: 0x0000164A
		public AddStallItemsPacket()
		{
			
			
		}

		// Token: 0x040006A4 RID: 1700
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 放入位置;

		// Token: 0x040006A5 RID: 1701
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 背包类型;

		// Token: 0x040006A6 RID: 1702
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 物品位置;

		// Token: 0x040006A7 RID: 1703
		[WrappingFieldAttribute(下标 = 5, 长度 = 1)]
		public ushort 物品数量;

		// Token: 0x040006A8 RID: 1704
		[WrappingFieldAttribute(下标 = 7, 长度 = 4)]
		public int 物品价格;
	}
}
