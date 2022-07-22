using System;

namespace GameServer.Networking
{
	// Token: 0x02000158 RID: 344
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 86, 长度 = 10, 注释 = "同步战力")]
	public sealed class SyncPlayerPowerPacket : GamePacket
	{
		// Token: 0x06000241 RID: 577 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncPlayerPowerPacket()
		{
			
			
		}

		// Token: 0x0400060D RID: 1549
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 角色编号;

		// Token: 0x0400060E RID: 1550
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 角色战力;
	}
}
