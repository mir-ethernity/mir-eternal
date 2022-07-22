using System;

namespace GameServer.Networking
{
	// Token: 0x0200006B RID: 107
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 21, 长度 = 6, 注释 = "同步角色战力")]
	public sealed class 同步角色战力 : GamePacket
	{
		// Token: 0x06000152 RID: 338 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步角色战力()
		{
			
			
		}

		// Token: 0x0400048D RID: 1165
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
