using System;

namespace GameServer.Networking
{
	// Token: 0x020001C4 RID: 452
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 517, 长度 = 6, 注释 = "玩家离开队伍")]
	public sealed class 玩家离开队伍 : GamePacket
	{
		// Token: 0x060002AD RID: 685 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家离开队伍()
		{
			
			
		}

		// Token: 0x040006F8 RID: 1784
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 队伍编号;
	}
}
