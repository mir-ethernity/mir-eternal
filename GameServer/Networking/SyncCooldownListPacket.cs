using System;

namespace GameServer.Networking
{
	// Token: 0x02000168 RID: 360
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 108, 长度 = 0, 注释 = "SyncCooldownListPacket")]
	public sealed class SyncCooldownListPacket : GamePacket
	{
		// Token: 0x06000251 RID: 593 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncCooldownListPacket()
		{
			
			
		}

		// Token: 0x04000649 RID: 1609
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节描述;
	}
}
