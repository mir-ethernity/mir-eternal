using System;

namespace GameServer.Networking
{
	// Token: 0x0200019B RID: 411
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 187, 长度 = 13, 注释 = "SyncClientVariablesPacket")]
	public sealed class SyncSupplementaryVariablesPacket : GamePacket
	{
		// Token: 0x06000284 RID: 644 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncSupplementaryVariablesPacket()
		{
			
			
		}

		// Token: 0x040006B8 RID: 1720
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 变量类型;

		// Token: 0x040006B9 RID: 1721
		[WrappingFieldAttribute(下标 = 3, 长度 = 2)]
		public ushort 变量索引;

		// Token: 0x040006BA RID: 1722
		[WrappingFieldAttribute(下标 = 5, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040006BB RID: 1723
		[WrappingFieldAttribute(下标 = 9, 长度 = 4)]
		public int 变量内容;
	}
}
