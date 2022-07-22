using System;

namespace GameServer.Networking
{
	// Token: 0x0200012B RID: 299
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 17, 长度 = 0, 注释 = "SyncBackpackInfoPacket")]
	public sealed class SyncBackpackInfoPacket : GamePacket
	{
		// Token: 0x06000214 RID: 532 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncBackpackInfoPacket()
		{
			
			
		}

		// Token: 0x04000594 RID: 1428
		[WrappingFieldAttribute(下标 = 6, 长度 = 0)]
		public byte[] 物品描述;
	}
}
