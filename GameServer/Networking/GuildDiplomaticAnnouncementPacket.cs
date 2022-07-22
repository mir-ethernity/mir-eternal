using System;

namespace GameServer.Networking
{
	// Token: 0x0200022D RID: 557
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 641, 长度 = 258, 注释 = "GuildDiplomaticAnnouncementPacket")]
	public sealed class GuildDiplomaticAnnouncementPacket : GamePacket
	{
		// Token: 0x06000316 RID: 790 RVA: 0x0000344A File Offset: 0x0000164A
		public GuildDiplomaticAnnouncementPacket()
		{
			
			
		}

		// Token: 0x04000788 RID: 1928
		[WrappingFieldAttribute(下标 = 2, 长度 = 256)]
		public byte[] 字节数据;
	}
}
