using System;

namespace GameServer.Networking
{
	// Token: 0x0200019F RID: 415
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 216, 长度 = 0, 注释 = "PutInTradeItemsPacket")]
	public sealed class PutInTradeItemsPacket : GamePacket
	{
		// Token: 0x06000288 RID: 648 RVA: 0x0000344A File Offset: 0x0000164A
		public PutInTradeItemsPacket()
		{
			
			
		}

		// Token: 0x040006C2 RID: 1730
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040006C3 RID: 1731
		[WrappingFieldAttribute(下标 = 8, 长度 = 1)]
		public byte 放入位置;

		// Token: 0x040006C4 RID: 1732
		[WrappingFieldAttribute(下标 = 9, 长度 = 1)]
		public byte 放入物品;

		// Token: 0x040006C5 RID: 1733
		[WrappingFieldAttribute(下标 = 10, 长度 = 0)]
		public byte[] 物品描述;
	}
}
