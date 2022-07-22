using System;

namespace GameServer.Networking
{
	// Token: 0x020001A2 RID: 418
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 250, 长度 = 38, 注释 = "玩家屏蔽目标")]
	public sealed class 玩家屏蔽目标 : GamePacket
	{
		// Token: 0x0600028B RID: 651 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家屏蔽目标()
		{
			
			
		}

		// Token: 0x040006CA RID: 1738
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040006CB RID: 1739
		[WrappingFieldAttribute(下标 = 6, 长度 = 32)]
		public string 对象名字;
	}
}
