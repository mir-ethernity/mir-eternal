using System;

namespace GameServer.Networking
{
	// Token: 0x020000F1 RID: 241
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 549, 长度 = 14, 注释 = "查看邮件内容")]
	public sealed class 查看邮件内容 : GamePacket
	{
		// Token: 0x060001D8 RID: 472 RVA: 0x0000344A File Offset: 0x0000164A
		public 查看邮件内容()
		{
			
			
		}

		// Token: 0x04000539 RID: 1337
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 邮件编号;
	}
}
