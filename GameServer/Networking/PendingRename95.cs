using System;

namespace GameServer.Networking
{
	// Token: 0x020001C3 RID: 451
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 516, 长度 = 0, 注释 = "玩家加入队伍")]
	public sealed class 玩家加入队伍 : GamePacket
	{
		// Token: 0x060002AC RID: 684 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家加入队伍()
		{
			
			
		}

		// Token: 0x040006F7 RID: 1783
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节描述;
	}
}
