using System;

namespace GameServer.Networking
{
	// Token: 0x02000109 RID: 265
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 573, 长度 = 8, 注释 = "GuildWarehouseMovePacket")]
	public sealed class GuildWarehouseMovePacket : GamePacket
	{
		// Token: 0x060001F0 RID: 496 RVA: 0x0000344A File Offset: 0x0000164A
		public GuildWarehouseMovePacket()
		{
			
			
		}

		// Token: 0x0400055A RID: 1370
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 原有页面;

		// Token: 0x0400055B RID: 1371
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 原有位置;

		// Token: 0x0400055C RID: 1372
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 目标页面;

		// Token: 0x0400055D RID: 1373
		[WrappingFieldAttribute(下标 = 5, 长度 = 1)]
		public byte 目标位置;
	}
}
