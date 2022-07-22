using System;

namespace GameServer.Networking
{
	// Token: 0x02000211 RID: 529
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 607, 长度 = 6, 注释 = "处理结盟申请")]
	public sealed class AffiliateAppResponsePacket : GamePacket
	{
		// Token: 0x060002FA RID: 762 RVA: 0x0000344A File Offset: 0x0000164A
		public AffiliateAppResponsePacket()
		{
			
			
		}

		// Token: 0x04000774 RID: 1908
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 行会编号;
	}
}
