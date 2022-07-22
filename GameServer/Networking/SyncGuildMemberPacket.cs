using System;

namespace GameServer.Networking
{
	// Token: 0x020001DD RID: 477
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 547, 长度 = 0, 注释 = "查询师门成员(师徒通用)")]
	public sealed class SyncGuildMemberPacket : GamePacket
	{
		// Token: 0x060002C6 RID: 710 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncGuildMemberPacket()
		{
			
			
		}

		// Token: 0x04000730 RID: 1840
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节数据;
	}
}
