using System;

namespace GameServer.Networking
{
	// Token: 0x0200022E RID: 558
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 642, 长度 = 10, 注释 = "申请敌对应答")]
	public sealed class 申请敌对应答 : GamePacket
	{
		// Token: 0x06000317 RID: 791 RVA: 0x0000344A File Offset: 0x0000164A
		public 申请敌对应答()
		{
			
			
		}

		// Token: 0x04000789 RID: 1929
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 行会编号;

		// Token: 0x0400078A RID: 1930
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 需要资金;
	}
}
