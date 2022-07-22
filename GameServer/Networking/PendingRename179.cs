using System;

namespace GameServer.Networking
{
	// Token: 0x0200021E RID: 542
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 620, 长度 = 0, 注释 = "更多GuildEvents")]
	public sealed class 同步GuildEvents : GamePacket
	{
		// Token: 0x06000307 RID: 775 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步GuildEvents()
		{
			
			
		}

		// Token: 0x04000784 RID: 1924
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节数据;
	}
}
