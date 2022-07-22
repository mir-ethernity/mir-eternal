using System;

namespace GameServer.Networking
{
	// Token: 0x02000111 RID: 273
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 588, 长度 = 38, 注释 = "玩家屏蔽对象")]
	public sealed class 玩家屏蔽对象 : GamePacket
	{
		// Token: 0x060001F8 RID: 504 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家屏蔽对象()
		{
			
			
		}

		// Token: 0x04000565 RID: 1381
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
