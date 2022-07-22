using System;

namespace GameServer.Networking
{
	// Token: 0x02000173 RID: 371
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 122, 长度 = 0, 注释 = "SelectTargetDetailsPacket")]
	public sealed class SelectTargetDetailsPacket : GamePacket
	{
		// Token: 0x0600025C RID: 604 RVA: 0x0000344A File Offset: 0x0000164A
		public SelectTargetDetailsPacket()
		{
			
			
		}

		// Token: 0x04000665 RID: 1637
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 对象编号;

		// Token: 0x04000666 RID: 1638
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int 当前体力;

		// Token: 0x04000667 RID: 1639
		[WrappingFieldAttribute(下标 = 12, 长度 = 4)]
		public int 当前魔力;

		// Token: 0x04000668 RID: 1640
		[WrappingFieldAttribute(下标 = 16, 长度 = 4)]
		public int 最大体力;

		// Token: 0x04000669 RID: 1641
		[WrappingFieldAttribute(下标 = 20, 长度 = 4)]
		public int 最大魔力;

		// Token: 0x0400066A RID: 1642
		[WrappingFieldAttribute(下标 = 24, 长度 = 1)]
		public byte[] Buff描述;
	}
}
