using System;

namespace GameServer.Networking
{
	// Token: 0x02000121 RID: 289
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 1004, 长度 = 6, 注释 = "彻底删除角色")]
	public sealed class 彻底删除角色 : GamePacket
	{
		// Token: 0x0600020A RID: 522 RVA: 0x0000344A File Offset: 0x0000164A
		public 彻底删除角色()
		{
			
			
		}

		// Token: 0x04000577 RID: 1399
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 角色编号;
	}
}
