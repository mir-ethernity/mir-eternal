using System;

namespace GameServer.Networking
{
	// Token: 0x02000195 RID: 405
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 163, 长度 = 11, 注释 = "StallItemsSoldPacket")]
	public sealed class StallItemsSoldPacket : GamePacket
	{
		// Token: 0x0600027E RID: 638 RVA: 0x0000344A File Offset: 0x0000164A
		public StallItemsSoldPacket()
		{
			
			
		}

		// Token: 0x040006B1 RID: 1713
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 物品位置;

		// Token: 0x040006B2 RID: 1714
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 售出数量;

		// Token: 0x040006B3 RID: 1715
		[WrappingFieldAttribute(下标 = 7, 长度 = 4)]
		public int 售出收益;
	}
}
