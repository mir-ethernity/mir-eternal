using System;

namespace GameServer.Networking
{
	// Token: 0x020000BA RID: 186
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 165, 长度 = 8, 注释 = "GuildWarehouseTransferPacket")]
	public sealed class GuildWarehouseTransferPacket : GamePacket
	{
		// Token: 0x060001A1 RID: 417 RVA: 0x0000344A File Offset: 0x0000164A
		public GuildWarehouseTransferPacket()
		{
			
			
		}

		// Token: 0x04000507 RID: 1287
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 原来容器;

		// Token: 0x04000508 RID: 1288
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 原来位置;

		// Token: 0x04000509 RID: 1289
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 仓库页面;

		// Token: 0x0400050A RID: 1290
		[WrappingFieldAttribute(下标 = 7, 长度 = 1)]
		public byte 仓库位置;
	}
}
