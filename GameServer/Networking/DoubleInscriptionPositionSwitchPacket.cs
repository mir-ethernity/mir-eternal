using System;

namespace GameServer.Networking
{
	// Token: 0x020001AF RID: 431
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 267, 长度 = 8, 注释 = "DoubleInscriptionPositionSwitchPacket")]
	public sealed class DoubleInscriptionPositionSwitchPacket : GamePacket
	{
		// Token: 0x06000298 RID: 664 RVA: 0x0000344A File Offset: 0x0000164A
		public DoubleInscriptionPositionSwitchPacket()
		{
			
			
		}

		// Token: 0x040006DF RID: 1759
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort 当前栏位;

		// Token: 0x040006E0 RID: 1760
		[WrappingFieldAttribute(下标 = 4, 长度 = 2)]
		public ushort 第一铭文;

		// Token: 0x040006E1 RID: 1761
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 第二铭文;
	}
}
