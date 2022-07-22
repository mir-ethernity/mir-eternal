using System;

namespace GameServer.Networking
{
	// Token: 0x020000F2 RID: 242
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 550, 长度 = 14, 注释 = "删除指定邮件")]
	public sealed class 删除指定邮件 : GamePacket
	{
		// Token: 0x060001D9 RID: 473 RVA: 0x0000344A File Offset: 0x0000164A
		public 删除指定邮件()
		{
			
			
		}

		// Token: 0x0400053A RID: 1338
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 邮件编号;
	}
}
