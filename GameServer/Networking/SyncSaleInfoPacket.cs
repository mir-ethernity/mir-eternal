using System;

namespace GameServer.Networking
{
	// Token: 0x02000234 RID: 564
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 660, 长度 = 0, 注释 = "查询出售信息")]
	public sealed class SyncSaleInfoPacket : GamePacket
	{
		// Token: 0x0600031D RID: 797 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncSaleInfoPacket()
		{
			
			
		}
	}
}
