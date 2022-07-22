using System;

namespace GameServer.Networking
{
	// Token: 0x0200023F RID: 575
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 687, 长度 = 499, 注释 = "跨服武道排名")]
	public sealed class SyncMartialArtsRankingPacket : GamePacket
	{
		// Token: 0x06000328 RID: 808 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncMartialArtsRankingPacket()
		{
			
			
		}
	}
}
