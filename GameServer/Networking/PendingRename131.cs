using System;

namespace GameServer.Networking
{
	// Token: 0x020001D5 RID: 469
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 538, 长度 = 6, 注释 = "删除仇人")]
	public sealed class 玩家移除仇人 : GamePacket
	{
		// Token: 0x060002BE RID: 702 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家移除仇人()
		{
			
			
		}

		// Token: 0x0400072C RID: 1836
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
