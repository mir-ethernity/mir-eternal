using System;

namespace GameServer.Networking
{
	// Token: 0x0200019D RID: 413
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 214, 长度 = 4, 注释 = "玩家失去称号")]
	public sealed class 玩家失去称号 : GamePacket
	{
		// Token: 0x06000286 RID: 646 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家失去称号()
		{
			
			
		}

		// Token: 0x040006BE RID: 1726
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 称号编号;
	}
}
