using System;

namespace GameServer.Networking
{
	// Token: 0x0200012F RID: 303
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 24, 长度 = 0, 注释 = "SyncTitleInfoPacket")]
	public sealed class SyncTitleInfoPacket : GamePacket
	{
		// Token: 0x06000218 RID: 536 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncTitleInfoPacket()
		{
			
			
		}

		// Token: 0x04000598 RID: 1432
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节描述;
	}
}
