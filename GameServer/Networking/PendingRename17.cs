using System;

namespace GameServer.Networking
{
	// Token: 0x02000061 RID: 97
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 10, 长度 = 6, 注释 = "更换角色")]
	public sealed class 客户更换角色 : GamePacket
	{
		// Token: 0x06000148 RID: 328 RVA: 0x0000344A File Offset: 0x0000164A
		public 客户更换角色()
		{
			
			
		}

		// Token: 0x04000483 RID: 1155
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 编号;
	}
}
