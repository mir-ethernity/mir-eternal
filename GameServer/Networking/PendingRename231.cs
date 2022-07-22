using System;

namespace GameServer.Networking
{
	// Token: 0x02000101 RID: 257
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 565, 长度 = 7, 注释 = "变更会员职位")]
	public sealed class 变更会员职位 : GamePacket
	{
		// Token: 0x060001E8 RID: 488 RVA: 0x0000344A File Offset: 0x0000164A
		public 变更会员职位()
		{
			
			
		}

		// Token: 0x0400054D RID: 1357
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x0400054E RID: 1358
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 对象职位;
	}
}
