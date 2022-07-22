using System;

namespace GameServer.Networking
{
	// Token: 0x02000187 RID: 391
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 149, 长度 = 30, 注释 = "货币数量变动")]
	public sealed class 货币数量变动 : GamePacket
	{
		// Token: 0x06000270 RID: 624 RVA: 0x0000344A File Offset: 0x0000164A
		public 货币数量变动()
		{
			
			
		}

		// Token: 0x0400069A RID: 1690
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 货币类型;

		// Token: 0x0400069B RID: 1691
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 货币数量;
	}
}
