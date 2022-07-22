using System;

namespace GameServer.Networking
{
	// Token: 0x020001AB RID: 427
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 259, 长度 = 31, 注释 = "DecompositionItemResponsePacket")]
	public sealed class DecompositionItemResponsePacket : GamePacket
	{
		// Token: 0x06000294 RID: 660 RVA: 0x0000344A File Offset: 0x0000164A
		public DecompositionItemResponsePacket()
		{
			
			
		}

		// Token: 0x040006D3 RID: 1747
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 分解数量;

		// Token: 0x040006D4 RID: 1748
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 分解物品;

		// Token: 0x040006D5 RID: 1749
		[WrappingFieldAttribute(下标 = 7, 长度 = 4)]
		public int 分解物一;

		// Token: 0x040006D6 RID: 1750
		[WrappingFieldAttribute(下标 = 11, 长度 = 4)]
		public int 分解物二;

		// Token: 0x040006D7 RID: 1751
		[WrappingFieldAttribute(下标 = 15, 长度 = 4)]
		public int 分解物三;

		// Token: 0x040006D8 RID: 1752
		[WrappingFieldAttribute(下标 = 19, 长度 = 4)]
		public int 物品数一;

		// Token: 0x040006D9 RID: 1753
		[WrappingFieldAttribute(下标 = 23, 长度 = 4)]
		public int 物品数二;

		// Token: 0x040006DA RID: 1754
		[WrappingFieldAttribute(下标 = 27, 长度 = 4)]
		public int 物品数三;
	}
}
