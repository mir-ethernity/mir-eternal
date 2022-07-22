using System;

namespace GameServer.Networking
{
	// Token: 0x02000208 RID: 520
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 598, 长度 = 7, 注释 = "GuildBanAnnouncementPacket")]
	public sealed class GuildBanAnnouncementPacket : GamePacket
	{
		// Token: 0x060002F1 RID: 753 RVA: 0x0000344A File Offset: 0x0000164A
		public GuildBanAnnouncementPacket()
		{
			
			
		}

		// Token: 0x04000768 RID: 1896
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x04000769 RID: 1897
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 禁言状态;
	}
}
