using System;

namespace GameServer.Networking
{
	// Token: 0x0200014F RID: 335
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 76, 长度 = 6, 注释 = "DoubleExpChangePacket")]
	public sealed class DoubleExpChangePacket : GamePacket
	{
		// Token: 0x06000238 RID: 568 RVA: 0x0000344A File Offset: 0x0000164A
		public DoubleExpChangePacket()
		{
			
			
		}

		// Token: 0x040005FA RID: 1530
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 双倍经验;
	}
}
