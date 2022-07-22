using System;

namespace GameServer.Networking
{
	// Token: 0x0200017D RID: 381
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 133, 长度 = 0, 注释 = "SyncRepoListPacket")]
	public sealed class SyncRepoListPacket : GamePacket
	{
		// Token: 0x06000266 RID: 614 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncRepoListPacket()
		{
			
			
		}

		// Token: 0x04000688 RID: 1672
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节描述;
	}
}
