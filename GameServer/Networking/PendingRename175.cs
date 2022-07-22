using System;

namespace GameServer.Networking
{
	// Token: 0x020001F5 RID: 501
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 575, 长度 = 674, 注释 = "查询邮件内容")]
	public sealed class 同步邮件内容 : GamePacket
	{
		// Token: 0x060002DE RID: 734 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步邮件内容()
		{
			
			
		}

		// Token: 0x0400074A RID: 1866
		[WrappingFieldAttribute(下标 = 2, 长度 = 672)]
		public byte[] 字节数据;
	}
}
