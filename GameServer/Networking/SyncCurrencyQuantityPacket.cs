using System;

namespace GameServer.Networking
{
	// Token: 0x02000186 RID: 390
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 148, 长度 = 0, 注释 = "SyncCurrencyQuantityPacket")]
	public sealed class SyncCurrencyQuantityPacket : GamePacket
	{
		// Token: 0x0600026F RID: 623 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncCurrencyQuantityPacket()
		{
			
			
		}

		// Token: 0x04000699 RID: 1689
		[WrappingFieldAttribute(下标 = 5, 长度 = 0)]
		public byte[] 字节描述;
	}
}
