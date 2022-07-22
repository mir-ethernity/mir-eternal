using System;

namespace GameServer.Networking
{
	// Token: 0x020001F4 RID: 500
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 574, 长度 = 0, 注释 = "QueryMailboxContentPacket")]
	public sealed class 同步邮箱内容 : GamePacket
	{
		// Token: 0x060002DD RID: 733 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步邮箱内容()
		{
			
			
		}

		// Token: 0x04000749 RID: 1865
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节数据;
	}
}
