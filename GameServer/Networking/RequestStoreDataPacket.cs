using System;

namespace GameServer.Networking
{
	// Token: 0x02000085 RID: 133
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 65, 长度 = 6, 注释 = "RequestStoreDataPacket")]
	public sealed class RequestStoreDataPacket : GamePacket
	{
		// Token: 0x0600016C RID: 364 RVA: 0x0000344A File Offset: 0x0000164A
		public RequestStoreDataPacket()
		{
			
			
		}

		// Token: 0x040004BA RID: 1210
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 版本编号;
	}
}
