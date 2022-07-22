using System;

namespace GameServer.Networking
{
	// Token: 0x020000E6 RID: 230
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 536, 长度 = 6, 注释 = "RefusedApplyApprenticeshipPacket")]
	public sealed class RefusedApplyApprenticeshipPacket : GamePacket
	{
		// Token: 0x060001CD RID: 461 RVA: 0x0000344A File Offset: 0x0000164A
		public RefusedApplyApprenticeshipPacket()
		{
			
			
		}

		// Token: 0x04000532 RID: 1330
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
