using System;

namespace GameServer.Networking
{
	// Token: 0x02000102 RID: 258
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 566, 长度 = 6, 注释 = "ExpelMembersPacket")]
	public sealed class ExpelMembersPacket : GamePacket
	{
		// Token: 0x060001E9 RID: 489 RVA: 0x0000344A File Offset: 0x0000164A
		public ExpelMembersPacket()
		{
			
			
		}

		// Token: 0x0400054F RID: 1359
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
