using System;

namespace GameServer.Networking
{
	// Token: 0x020000D5 RID: 213
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 517, 长度 = 6, 注释 = "申请离开队伍")]
	public sealed class 申请离开队伍 : GamePacket
	{
		// Token: 0x060001BC RID: 444 RVA: 0x0000344A File Offset: 0x0000164A
		public 申请离开队伍()
		{
			
			
		}

		// Token: 0x04000523 RID: 1315
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
