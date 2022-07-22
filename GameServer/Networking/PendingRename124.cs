using System;

namespace GameServer.Networking
{
	// Token: 0x020000AE RID: 174
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 149, 长度 = 6, 注释 = "玩家放入金币")]
	public sealed class 玩家放入金币 : GamePacket
	{
		// Token: 0x06000195 RID: 405 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家放入金币()
		{
			
			
		}

		// Token: 0x040004FD RID: 1277
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 金币数量;
	}
}
