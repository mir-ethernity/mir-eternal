using System;

namespace GameServer.Networking
{
	// Token: 0x02000080 RID: 128
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 53, 长度 = 4, 注释 = "商店修理单件")]
	public sealed class 商店修理单件 : GamePacket
	{
		// Token: 0x06000167 RID: 359 RVA: 0x0000344A File Offset: 0x0000164A
		public 商店修理单件()
		{
			
			
		}

		// Token: 0x040004B3 RID: 1203
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 背包类型;

		// Token: 0x040004B4 RID: 1204
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 物品位置;
	}
}
