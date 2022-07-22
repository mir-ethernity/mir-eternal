using System;

namespace GameServer.Networking
{
	// Token: 0x020001E2 RID: 482
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 552, 长度 = 6, 注释 = "RefusedApplyApprenticeshipPacket")]
	public sealed class 拜师申请拒绝 : GamePacket
	{
		// Token: 0x060002CB RID: 715 RVA: 0x0000344A File Offset: 0x0000164A
		public 拜师申请拒绝()
		{
			
			
		}

		// Token: 0x04000736 RID: 1846
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
