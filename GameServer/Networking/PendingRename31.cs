using System;

namespace GameServer.Networking
{
	// Token: 0x020001F7 RID: 503
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 577, 长度 = 6, 注释 = "未读邮件提醒")]
	public sealed class 未读邮件提醒 : GamePacket
	{
		// Token: 0x060002E0 RID: 736 RVA: 0x0000344A File Offset: 0x0000164A
		public 未读邮件提醒()
		{
			
			
		}

		// Token: 0x0400074C RID: 1868
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 邮件数量;
	}
}
