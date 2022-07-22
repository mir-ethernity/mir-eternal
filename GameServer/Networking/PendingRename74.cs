using System;

namespace GameServer.Networking
{
	// Token: 0x020000EF RID: 239
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 547, 长度 = 0, 注释 = "申请发送邮件")]
	public sealed class 申请发送邮件 : GamePacket
	{
		// Token: 0x060001D6 RID: 470 RVA: 0x0000344A File Offset: 0x0000164A
		public 申请发送邮件()
		{
			
			
		}

		// Token: 0x04000538 RID: 1336
		[WrappingFieldAttribute(下标 = 2, 长度 = 0)]
		public byte[] 字节数据;
	}
}
