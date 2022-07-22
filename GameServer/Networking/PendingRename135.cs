using System;

namespace GameServer.Networking
{
	// Token: 0x020000AA RID: 170
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 145, 长度 = 3, 注释 = "玩家装配称号")]
	public sealed class 玩家装配称号 : GamePacket
	{
		// Token: 0x06000191 RID: 401 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家装配称号()
		{
			
			
		}

		// Token: 0x040004FA RID: 1274
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public byte 称号编号;
	}
}
