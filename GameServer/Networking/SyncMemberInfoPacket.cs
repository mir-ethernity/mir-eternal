using System;

namespace GameServer.Networking
{
	// Token: 0x0200022F RID: 559
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 646, 长度 = 11, 注释 = "SyncMemberInfoPacket")]
	public sealed class SyncMemberInfoPacket : GamePacket
	{
		// Token: 0x06000318 RID: 792 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncMemberInfoPacket()
		{
			
			
		}

		// Token: 0x0400078B RID: 1931
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x0400078C RID: 1932
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 对象信息;

		// Token: 0x0400078D RID: 1933
		[WrappingFieldAttribute(下标 = 10, 长度 = 1)]
		public byte 当前等级;
	}
}
