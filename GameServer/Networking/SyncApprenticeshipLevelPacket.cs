using System;

namespace GameServer.Networking
{
	// Token: 0x020001DE RID: 478
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 548, 长度 = 7, 注释 = "SyncApprenticeshipLevelPacket")]
	public sealed class SyncApprenticeshipLevelPacket : GamePacket
	{
		// Token: 0x060002C7 RID: 711 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncApprenticeshipLevelPacket()
		{
			
			
		}

		// Token: 0x04000731 RID: 1841
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x04000732 RID: 1842
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 对象等级;
	}
}
