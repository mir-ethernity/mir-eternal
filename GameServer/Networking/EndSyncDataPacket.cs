using System;

namespace GameServer.Networking
{
	// Token: 0x02000132 RID: 306
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 33, 长度 = 6, 注释 = "同步GameData结束")]
	public sealed class EndSyncDataPacket : GamePacket
	{
		// Token: 0x0600021B RID: 539 RVA: 0x0000344A File Offset: 0x0000164A
		public EndSyncDataPacket()
		{
			
			
		}

		// Token: 0x0400059C RID: 1436
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 角色编号;
	}
}
