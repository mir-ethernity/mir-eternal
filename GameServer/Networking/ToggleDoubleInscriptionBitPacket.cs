using System;

namespace GameServer.Networking
{
	// Token: 0x0200008D RID: 141
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 75, 长度 = 5, 注释 = "ToggleDoubleInscriptionBitPacket")]
	public sealed class ToggleDoubleInscriptionBitPacket : GamePacket
	{
		// Token: 0x06000174 RID: 372 RVA: 0x0000344A File Offset: 0x0000164A
		public ToggleDoubleInscriptionBitPacket()
		{
			
			
		}

		// Token: 0x040004D2 RID: 1234
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 装备类型;

		// Token: 0x040004D3 RID: 1235
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 装备位置;

		// Token: 0x040004D4 RID: 1236
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 操作参数;
	}
}
