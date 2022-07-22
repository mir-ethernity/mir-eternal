using System;

namespace GameServer.Networking
{
	// Token: 0x02000193 RID: 403
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 161, 长度 = 0, 注释 = "SyncBoothDataPacket")]
	public sealed class SyncBoothDataPacket : GamePacket
	{
		// Token: 0x0600027C RID: 636 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncBoothDataPacket()
		{
			
			
		}

		// Token: 0x040006AC RID: 1708
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040006AD RID: 1709
		[WrappingFieldAttribute(下标 = 8, 长度 = 0)]
		public byte[] 字节数据;
	}
}
