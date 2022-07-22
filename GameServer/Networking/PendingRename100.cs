using System;

namespace GameServer.Networking
{
	// Token: 0x020000AC RID: 172
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 147, 长度 = 6, 注释 = "玩家申请交易")]
	public sealed class 玩家申请交易 : GamePacket
	{
		// Token: 0x06000193 RID: 403 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家申请交易()
		{
			
			
		}

		// Token: 0x040004FB RID: 1275
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
