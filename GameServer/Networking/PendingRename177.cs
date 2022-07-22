using System;

namespace GameServer.Networking
{
	// Token: 0x02000156 RID: 342
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 83, 长度 = 7, 注释 = "玩家装配称号")]
	public sealed class 同步装配称号 : GamePacket
	{
		// Token: 0x0600023F RID: 575 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步装配称号()
		{
			
			
		}

		// Token: 0x04000609 RID: 1545
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x0400060A RID: 1546
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 称号编号;
	}
}
