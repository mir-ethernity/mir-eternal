using System;

namespace GameServer.Networking
{
	// Token: 0x020001B3 RID: 435
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 288, 长度 = 5, 注释 = "同步签到信息")]
	public sealed class 同步签到信息 : GamePacket
	{
		// Token: 0x0600029C RID: 668 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步签到信息()
		{
			
			
		}

		// Token: 0x040006E4 RID: 1764
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public bool 能否签到;

		// Token: 0x040006E5 RID: 1765
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 签到次数;
	}
}
