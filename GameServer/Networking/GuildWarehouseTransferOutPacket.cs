using System;

namespace GameServer.Networking
{
	// Token: 0x020000BB RID: 187
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 166, 长度 = 8, 注释 = "GuildWarehouseTransferOutPacket")]
	public sealed class GuildWarehouseTransferOutPacket : GamePacket
	{
		// Token: 0x060001A2 RID: 418 RVA: 0x0000344A File Offset: 0x0000164A
		public GuildWarehouseTransferOutPacket()
		{
			
			
		}

		// Token: 0x0400050B RID: 1291
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 仓库页面;

		// Token: 0x0400050C RID: 1292
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 仓库位置;

		// Token: 0x0400050D RID: 1293
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 目标容器;

		// Token: 0x0400050E RID: 1294
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 目标位置;
	}
}
