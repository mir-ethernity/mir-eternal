using System;

namespace GameServer.Networking
{
	// Token: 0x02000148 RID: 328
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 68, 长度 = 0, 注释 = "SyncBlacklistPacket")]
	public sealed class SyncBlacklistPacket : GamePacket
	{
		// Token: 0x06000231 RID: 561 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncBlacklistPacket()
		{
			
			
		}

		// Token: 0x040005EC RID: 1516
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节描述;
	}
}
