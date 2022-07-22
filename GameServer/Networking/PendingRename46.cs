using System;

namespace GameServer.Networking
{
	// Token: 0x020001FF RID: 511
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 588, 长度 = 6, 注释 = "加入行会回应")]
	public sealed class 加入行会应答 : GamePacket
	{
		// Token: 0x060002E8 RID: 744 RVA: 0x0000344A File Offset: 0x0000164A
		public 加入行会应答()
		{
			
			
		}

		// Token: 0x04000758 RID: 1880
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 行会编号;
	}
}
