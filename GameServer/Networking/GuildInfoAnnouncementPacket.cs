using System;

namespace GameServer.Networking
{
	// Token: 0x020001FE RID: 510
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 587, 长度 = 0, 注释 = "GuildInfoAnnouncementPacket")]
	public sealed class GuildInfoAnnouncementPacket : GamePacket
	{
		// Token: 0x060002E7 RID: 743 RVA: 0x0000344A File Offset: 0x0000164A
		public GuildInfoAnnouncementPacket()
		{
			
			
		}

		// Token: 0x04000757 RID: 1879
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节数据;
	}
}
