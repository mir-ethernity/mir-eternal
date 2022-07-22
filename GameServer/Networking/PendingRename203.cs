using System;

namespace GameServer.Networking
{
	// Token: 0x020000D2 RID: 210
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 254, 长度 = 6, 注释 = "购买每周特惠")]
	public sealed class 购买每周特惠 : GamePacket
	{
		// Token: 0x060001B9 RID: 441 RVA: 0x0000344A File Offset: 0x0000164A
		public 购买每周特惠()
		{
			
			
		}

		// Token: 0x04000520 RID: 1312
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 礼包编号;
	}
}
