using System;

namespace GameServer.Networking
{
	// Token: 0x020001CA RID: 458
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 523, 长度 = 7, 注释 = "同步队员状态")]
	public sealed class 同步队员状态 : GamePacket
	{
		// Token: 0x060002B3 RID: 691 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步队员状态()
		{
			
			
		}

		// Token: 0x04000717 RID: 1815
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x04000718 RID: 1816
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 状态编号;
	}
}
