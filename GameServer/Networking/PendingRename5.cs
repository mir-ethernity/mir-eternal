using System;

namespace GameServer.Networking
{
	// Token: 0x02000120 RID: 288
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 1003, 长度 = 6, 注释 = "删除角色")]
	public sealed class 客户删除角色 : GamePacket
	{
		// Token: 0x06000209 RID: 521 RVA: 0x0000344A File Offset: 0x0000164A
		public 客户删除角色()
		{
			
			
		}

		// Token: 0x04000576 RID: 1398
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 角色编号;
	}
}
