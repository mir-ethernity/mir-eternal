using System;

namespace GameServer.Networking
{
	// Token: 0x020001F6 RID: 502
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 576, 长度 = 14, 注释 = "EmailDeletedOkPacket")]
	public sealed class EmailDeletedOkPacket : GamePacket
	{
		// Token: 0x060002DF RID: 735 RVA: 0x0000344A File Offset: 0x0000164A
		public EmailDeletedOkPacket()
		{
			
			
		}

		// Token: 0x0400074B RID: 1867
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 邮件编号;
	}
}
