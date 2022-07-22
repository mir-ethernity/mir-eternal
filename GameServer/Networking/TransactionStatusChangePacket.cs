using System;

namespace GameServer.Networking
{
	// Token: 0x0200019E RID: 414
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 215, 长度 = 11, 注释 = "TransactionStatusChangePacket")]
	public sealed class TransactionStatusChangePacket : GamePacket
	{
		// Token: 0x06000287 RID: 647 RVA: 0x0000344A File Offset: 0x0000164A
		public TransactionStatusChangePacket()
		{
			
			
		}

		// Token: 0x040006BF RID: 1727
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040006C0 RID: 1728
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 交易状态;

		// Token: 0x040006C1 RID: 1729
		[WrappingFieldAttribute(下标 = 7, 长度 = 4)]
		public int 对象等级;
	}
}
