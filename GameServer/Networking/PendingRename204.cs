using System;

namespace GameServer.Networking
{
	// Token: 0x02000117 RID: 279
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 613, 长度 = 4, 注释 = "购买玛法特权")]
	public sealed class 购买玛法特权 : GamePacket
	{
		// Token: 0x060001FE RID: 510 RVA: 0x0000344A File Offset: 0x0000164A
		public 购买玛法特权()
		{
			
			
		}

		// Token: 0x0400056B RID: 1387
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 特权类型;

		// Token: 0x0400056C RID: 1388
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 购买数量;
	}
}
