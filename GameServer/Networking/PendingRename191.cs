using System;

namespace GameServer.Networking
{
	// Token: 0x020000C7 RID: 199
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 216, 长度 = 4, 注释 = "领取特权礼包")]
	public sealed class 领取特权礼包 : GamePacket
	{
		// Token: 0x060001AE RID: 430 RVA: 0x0000344A File Offset: 0x0000164A
		public 领取特权礼包()
		{
			
			
		}

		// Token: 0x04000516 RID: 1302
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 特权类型;

		// Token: 0x04000517 RID: 1303
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 礼包位置;
	}
}
