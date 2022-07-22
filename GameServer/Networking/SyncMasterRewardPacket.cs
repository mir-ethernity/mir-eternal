using System;

namespace GameServer.Networking
{
	// Token: 0x02000159 RID: 345
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 87, 长度 = 94, 注释 = "SyncMasterRewardPacket(师徒通用)")]
	public sealed class SyncMasterRewardPacket : GamePacket
	{
		// Token: 0x06000242 RID: 578 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncMasterRewardPacket()
		{
			
			
		}

		// Token: 0x0400060F RID: 1551
		[WrappingFieldAttribute(下标 = 2, 长度 = 92)]
		public byte[] 字节数据;
	}
}
