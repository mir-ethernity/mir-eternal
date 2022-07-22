using System;

namespace GameServer.Networking
{
	// Token: 0x0200012A RID: 298
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 15, 长度 = 11, 注释 = "SyncBackpackSizePacket 仓库 背包 资源包...")]
	public sealed class SyncBackpackSizePacket : GamePacket
	{
		// Token: 0x06000213 RID: 531 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncBackpackSizePacket()
		{
			
			
		}

		// Token: 0x04000591 RID: 1425
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 穿戴大小;

		// Token: 0x04000592 RID: 1426
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 背包大小;

		// Token: 0x04000593 RID: 1427
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 仓库大小;
	}
}
