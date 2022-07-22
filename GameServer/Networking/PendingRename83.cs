using System;

namespace GameServer.Networking
{
	// Token: 0x020001E7 RID: 487
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 559, 长度 = 6, 注释 = "RejectionApprenticeshipAppPacket")]
	public sealed class 收徒申请拒绝 : GamePacket
	{
		// Token: 0x060002D0 RID: 720 RVA: 0x0000344A File Offset: 0x0000164A
		public 收徒申请拒绝()
		{
			
			
		}

		// Token: 0x0400073E RID: 1854
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
