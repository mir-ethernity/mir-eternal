using System;

namespace GameServer.Networking
{
	// Token: 0x02000214 RID: 532
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 610, 长度 = 3, 注释 = "SendGuildNoticePacket")]
	public sealed class SendGuildNoticePacket : GamePacket
	{
		// Token: 0x060002FD RID: 765 RVA: 0x0000344A File Offset: 0x0000164A
		public SendGuildNoticePacket()
		{
			
			
		}

		// Token: 0x0400077D RID: 1917
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 提醒类型;
	}
}
