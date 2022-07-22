using System;

namespace GameServer.Networking
{
	// Token: 0x02000190 RID: 400
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 158, 长度 = 3, 注释 = "RemoveStallItemsPacket")]
	public sealed class RemoveStallItemsPacket : GamePacket
	{
		// Token: 0x06000279 RID: 633 RVA: 0x0000344A File Offset: 0x0000164A
		public RemoveStallItemsPacket()
		{
			
			
		}

		// Token: 0x040006A9 RID: 1705
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 取回位置;
	}
}
