using System;

namespace GameServer.Networking
{
	// Token: 0x020000B9 RID: 185
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 164, 长度 = 8, 注释 = "GuildWarehouseRefreshPacket")]
	public sealed class GuildWarehouseRefreshPacket : GamePacket
	{
		// Token: 0x060001A0 RID: 416 RVA: 0x0000344A File Offset: 0x0000164A
		public GuildWarehouseRefreshPacket()
		{
			
			
		}

		// Token: 0x04000506 RID: 1286
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 仓库页面;
	}
}
