using System;

namespace GameServer.Networking
{
	// Token: 0x020000F3 RID: 243
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 551, 长度 = 14, 注释 = "提取邮件附件")]
	public sealed class 提取邮件附件 : GamePacket
	{
		// Token: 0x060001DA RID: 474 RVA: 0x0000344A File Offset: 0x0000164A
		public 提取邮件附件()
		{
			
			
		}

		// Token: 0x0400053B RID: 1339
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 邮件编号;
	}
}
