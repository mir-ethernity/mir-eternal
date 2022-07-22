using System;

namespace GameServer.Networking
{
	// Token: 0x020000A1 RID: 161
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 114, 长度 = 10, 注释 = "玩家完成任务")]
	public sealed class 玩家完成任务 : GamePacket
	{
		// Token: 0x06000188 RID: 392 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家完成任务()
		{
			
			
		}

		// Token: 0x040004F3 RID: 1267
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
