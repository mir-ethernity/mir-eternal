using System;

namespace GameServer.Networking
{
	// Token: 0x0200018E RID: 398
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 156, 长度 = 7, 注释 = "摆摊状态改变")]
	public sealed class 摆摊状态改变 : GamePacket
	{
		// Token: 0x06000277 RID: 631 RVA: 0x0000344A File Offset: 0x0000164A
		public 摆摊状态改变()
		{
			
			
		}

		// Token: 0x040006A2 RID: 1698
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040006A3 RID: 1699
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 摊位状态;
	}
}
