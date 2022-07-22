using System;

namespace GameServer.Networking
{
	// Token: 0x02000181 RID: 385
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 137, 长度 = 4, 注释 = "背包容量改变")]
	public sealed class 背包容量改变 : GamePacket
	{
		// Token: 0x0600026A RID: 618 RVA: 0x0000344A File Offset: 0x0000164A
		public 背包容量改变()
		{
			
			
		}

		// Token: 0x0400068C RID: 1676
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 背包类型;

		// Token: 0x0400068D RID: 1677
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 背包容量;
	}
}
