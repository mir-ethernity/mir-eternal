using System;

namespace GameServer.Networking
{
	// Token: 0x02000194 RID: 404
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 162, 长度 = 11, 注释 = "购买摊位物品")]
	public sealed class 购入摊位物品 : GamePacket
	{
		// Token: 0x0600027D RID: 637 RVA: 0x0000344A File Offset: 0x0000164A
		public 购入摊位物品()
		{
			
			
		}

		// Token: 0x040006AE RID: 1710
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040006AF RID: 1711
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 物品位置;

		// Token: 0x040006B0 RID: 1712
		[WrappingFieldAttribute(下标 = 7, 长度 = 4)]
		public int 剩余数量;
	}
}
