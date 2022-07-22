using System;

namespace GameServer.Networking
{
	// Token: 0x020001F8 RID: 504
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 578, 长度 = 14, 注释 = "提取附件成功")]
	public sealed class 成功提取附件 : GamePacket
	{
		// Token: 0x060002E1 RID: 737 RVA: 0x0000344A File Offset: 0x0000164A
		public 成功提取附件()
		{
			
			
		}

		// Token: 0x0400074D RID: 1869
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 邮件编号;
	}
}
