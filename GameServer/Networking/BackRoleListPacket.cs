using System;

namespace GameServer.Networking
{
	// Token: 0x02000243 RID: 579
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1004, 长度 = 849, 注释 = "同步角色列表")]
	public sealed class BackRoleListPacket : GamePacket
	{
		// Token: 0x0600032E RID: 814 RVA: 0x0000344A File Offset: 0x0000164A
		public BackRoleListPacket()
		{
			
			
		}

		// Token: 0x0400079D RID: 1949
		[WrappingFieldAttribute(下标 = 2, 长度 = 846)]
		public byte[] 列表描述;
	}
}
