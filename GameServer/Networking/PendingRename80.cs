using System;

namespace GameServer.Networking
{
	// Token: 0x02000100 RID: 256
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 564, 长度 = 7, 注释 = "设置行会禁言")]
	public sealed class 设置行会禁言 : GamePacket
	{
		// Token: 0x060001E7 RID: 487 RVA: 0x0000344A File Offset: 0x0000164A
		public 设置行会禁言()
		{
			
			
		}

		// Token: 0x0400054B RID: 1355
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 禁言状态;

		// Token: 0x0400054C RID: 1356
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 对象编号;
	}
}
