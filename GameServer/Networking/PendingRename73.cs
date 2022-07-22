using System;

namespace GameServer.Networking
{
	// Token: 0x020000D6 RID: 214
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 519, 长度 = 44, 注释 = "申请更改队伍")]
	public sealed class 申请更改队伍 : GamePacket
	{
		// Token: 0x060001BD RID: 445 RVA: 0x0000344A File Offset: 0x0000164A
		public 申请更改队伍()
		{
			
			
		}

		// Token: 0x04000524 RID: 1316
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 成员上限;

		// Token: 0x04000525 RID: 1317
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int 队长编号;
	}
}
