using System;

namespace GameServer.Networking
{
	// Token: 0x020001D4 RID: 468
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 537, 长度 = 6, 注释 = "添加仇人")]
	public sealed class 玩家标记仇人 : GamePacket
	{
		// Token: 0x060002BD RID: 701 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家标记仇人()
		{
			
			
		}

		// Token: 0x0400072B RID: 1835
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
