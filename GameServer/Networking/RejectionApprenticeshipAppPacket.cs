using System;

namespace GameServer.Networking
{
	// Token: 0x020000E9 RID: 233
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 540, 长度 = 6, 注释 = "RejectionApprenticeshipAppPacket")]
	public sealed class RejectionApprenticeshipAppPacket : GamePacket
	{
		// Token: 0x060001D0 RID: 464 RVA: 0x0000344A File Offset: 0x0000164A
		public RejectionApprenticeshipAppPacket()
		{
			
			
		}

		// Token: 0x04000535 RID: 1333
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
