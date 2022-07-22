using System;

namespace GameServer.Networking
{
	// Token: 0x020000A2 RID: 162
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 115, 长度 = 6, 注释 = "玩家放弃任务")]
	public sealed class 玩家放弃任务 : GamePacket
	{
		// Token: 0x06000189 RID: 393 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家放弃任务()
		{
			
			
		}

		// Token: 0x040004F4 RID: 1268
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
