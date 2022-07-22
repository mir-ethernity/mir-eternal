using System;

namespace GameServer.Networking
{
	// Token: 0x020001D6 RID: 470
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 539, 长度 = 10, 注释 = "同步亲密度")]
	public sealed class SyncFriendsIntimacyPacket : GamePacket
	{
		// Token: 0x060002BF RID: 703 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncFriendsIntimacyPacket()
		{
			
			
		}
	}
}
