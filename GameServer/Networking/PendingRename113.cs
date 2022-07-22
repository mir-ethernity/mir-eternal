using System;

namespace GameServer.Networking
{
	// Token: 0x020000BF RID: 191
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 181, 长度 = 6, 注释 = "玩家解除屏蔽")]
	public sealed class 玩家解除屏蔽 : GamePacket
	{
		// Token: 0x060001A6 RID: 422 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家解除屏蔽()
		{
			
			
		}

		// Token: 0x04000514 RID: 1300
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
