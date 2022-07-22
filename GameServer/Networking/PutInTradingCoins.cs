using System;

namespace GameServer.Networking
{
	// Token: 0x020001A0 RID: 416
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 217, 长度 = 10, 注释 = "PutInTradingCoins")]
	public sealed class PutInTradingCoins : GamePacket
	{
		// Token: 0x06000289 RID: 649 RVA: 0x0000344A File Offset: 0x0000164A
		public PutInTradingCoins()
		{
			
			
		}

		// Token: 0x040006C6 RID: 1734
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040006C7 RID: 1735
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 金币数量;
	}
}
