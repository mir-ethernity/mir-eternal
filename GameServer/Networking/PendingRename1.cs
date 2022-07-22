using System;

namespace GameServer.Networking
{
	// Token: 0x020001B4 RID: 436
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 289, 长度 = 3, 注释 = "玩家每日签到")]
	public sealed class 每日签到应答 : GamePacket
	{
		// Token: 0x0600029D RID: 669 RVA: 0x0000344A File Offset: 0x0000164A
		public 每日签到应答()
		{
			
			
		}

		// Token: 0x040006E6 RID: 1766
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 签到次数;
	}
}
