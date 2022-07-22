using System;

namespace GameServer.Networking
{
	// Token: 0x020000B8 RID: 184
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 163, 长度 = 6, 注释 = "DonateGuildFundsPacket")]
	public sealed class DonateGuildFundsPacket : GamePacket
	{
		// Token: 0x0600019F RID: 415 RVA: 0x0000344A File Offset: 0x0000164A
		public DonateGuildFundsPacket()
		{
			
			
		}

		// Token: 0x04000505 RID: 1285
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 金币数量;
	}
}
