using System;

namespace GameServer.Networking
{
	// Token: 0x020000E7 RID: 231
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 538, 长度 = 7, 注释 = "玩家申请收徒")]
	public sealed class 玩家申请收徒 : GamePacket
	{
		// Token: 0x060001CE RID: 462 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家申请收徒()
		{
			
			
		}

		// Token: 0x04000533 RID: 1331
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 对象编号;
	}
}
