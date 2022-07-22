using System;

namespace GameServer.Networking
{
	// Token: 0x02000094 RID: 148
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 93, 长度 = 8, 注释 = "随身修理单件")]
	public sealed class 随身修理单件 : GamePacket
	{
		// Token: 0x0600017B RID: 379 RVA: 0x0000344A File Offset: 0x0000164A
		public 随身修理单件()
		{
			
			
		}

		// Token: 0x040004E3 RID: 1251
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 物品容器;

		// Token: 0x040004E4 RID: 1252
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 物品位置;

		// Token: 0x040004E5 RID: 1253
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 物品编号;
	}
}
