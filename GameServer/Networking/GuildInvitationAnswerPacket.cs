using System;

namespace GameServer.Networking
{
	// Token: 0x02000205 RID: 517
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 595, 长度 = 35, 注释 = "GuildInvitationAnswerPacket")]
	public sealed class GuildInvitationAnswerPacket : GamePacket
	{
		// Token: 0x060002EE RID: 750 RVA: 0x0000344A File Offset: 0x0000164A
		public GuildInvitationAnswerPacket()
		{
			
			
		}

		// Token: 0x04000765 RID: 1893
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 应答类型;

		// Token: 0x04000766 RID: 1894
		[WrappingFieldAttribute(下标 = 3, 长度 = 32)]
		public string 对象名字;
	}
}
