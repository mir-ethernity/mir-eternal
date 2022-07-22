using System;

namespace GameServer.Networking
{
	// Token: 0x020000DF RID: 223
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 528, 长度 = 6, 注释 = "删除仇人")]
	public sealed class 玩家删除仇人 : GamePacket
	{
		// Token: 0x060001C6 RID: 454 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家删除仇人()
		{
			
			
		}

		// Token: 0x0400052E RID: 1326
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
