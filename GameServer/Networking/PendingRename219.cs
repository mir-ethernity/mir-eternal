using System;

namespace GameServer.Networking
{
	// Token: 0x02000089 RID: 137
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 71, 长度 = 6, 注释 = "传承武器铭文")]
	public sealed class 传承武器铭文 : GamePacket
	{
		// Token: 0x06000170 RID: 368 RVA: 0x0000344A File Offset: 0x0000164A
		public 传承武器铭文()
		{
			
			
		}

		// Token: 0x040004C6 RID: 1222
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 来源类型;

		// Token: 0x040004C7 RID: 1223
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 来源位置;

		// Token: 0x040004C8 RID: 1224
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 目标类型;

		// Token: 0x040004C9 RID: 1225
		[WrappingFieldAttribute(下标 = 5, 长度 = 1)]
		public byte 目标位置;
	}
}
