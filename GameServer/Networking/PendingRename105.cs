using System;

namespace GameServer.Networking
{
	// Token: 0x02000180 RID: 384
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 136, 长度 = 10, 注释 = "拾取金币")]
	public sealed class 玩家拾取金币 : GamePacket
	{
		// Token: 0x06000269 RID: 617 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家拾取金币()
		{
			
			
		}

		// Token: 0x0400068B RID: 1675
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 金币数量;
	}
}
