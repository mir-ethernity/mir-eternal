using System;

namespace GameServer.Networking
{
	// Token: 0x020000B4 RID: 180
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 156, 长度 = 6, 注释 = "玩家比较成就")]
	public sealed class 玩家比较成就 : GamePacket
	{
		// Token: 0x0600019B RID: 411 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家比较成就()
		{
			
			
		}

		// Token: 0x04000502 RID: 1282
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
