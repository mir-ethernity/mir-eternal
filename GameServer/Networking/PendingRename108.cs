using System;

namespace GameServer.Networking
{
	// Token: 0x020000AD RID: 173
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 148, 长度 = 6, 注释 = "玩家同意交易")]
	public sealed class 玩家同意交易 : GamePacket
	{
		// Token: 0x06000194 RID: 404 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家同意交易()
		{
			
			
		}

		// Token: 0x040004FC RID: 1276
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
