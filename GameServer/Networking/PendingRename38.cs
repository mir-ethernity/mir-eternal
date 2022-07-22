using System;

namespace GameServer.Networking
{
	// Token: 0x0200010D RID: 269
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 581, 长度 = 6, 注释 = "开启行会活动")]
	public sealed class 开启行会活动 : GamePacket
	{
		// Token: 0x060001F4 RID: 500 RVA: 0x0000344A File Offset: 0x0000164A
		public 开启行会活动()
		{
			
			
		}

		// Token: 0x0400055F RID: 1375
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 活动编号;
	}
}
