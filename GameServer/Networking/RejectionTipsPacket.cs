using System;

namespace GameServer.Networking
{
	// Token: 0x020001E8 RID: 488
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 560, 长度 = 6, 注释 = "RejectionTipsPacket")]
	public sealed class RejectionTipsPacket : GamePacket
	{
		// Token: 0x060002D1 RID: 721 RVA: 0x0000344A File Offset: 0x0000164A
		public RejectionTipsPacket()
		{
			
			
		}

		// Token: 0x0400073F RID: 1855
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
