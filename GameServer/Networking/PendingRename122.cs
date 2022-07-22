using System;

namespace GameServer.Networking
{
	// Token: 0x020001AC RID: 428
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 264, 长度 = 16, 注释 = "高级铭文洗练")]
	public sealed class 玩家高级洗练 : GamePacket
	{
		// Token: 0x06000295 RID: 661 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家高级洗练()
		{
			
			
		}

		// Token: 0x040006DB RID: 1755
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort 洗练结果;

		// Token: 0x040006DC RID: 1756
		[WrappingFieldAttribute(下标 = 4, 长度 = 2)]
		public ushort 铭文位一;

		// Token: 0x040006DD RID: 1757
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 铭文位二;
	}
}
