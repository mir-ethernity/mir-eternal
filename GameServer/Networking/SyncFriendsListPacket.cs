using System;

namespace GameServer.Networking
{
	// Token: 0x020001CD RID: 461
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 530, 长度 = 0, 注释 = "SyncFriendsListPacket")]
	public sealed class SyncFriendsListPacket : GamePacket
	{
		// Token: 0x060002B6 RID: 694 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncFriendsListPacket()
		{
			
			
		}

		// Token: 0x0400071C RID: 1820
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节描述;
	}
}
