using System;

namespace GameServer.Networking
{
	// Token: 0x020001A7 RID: 423
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 255, 长度 = 6, 注释 = "OrdinaryInscriptionRefinementPacket")]
	public sealed class 玩家普通洗练 : GamePacket
	{
		// Token: 0x06000290 RID: 656 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家普通洗练()
		{
			
			
		}

		// Token: 0x040006D0 RID: 1744
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort 铭文位一;

		// Token: 0x040006D1 RID: 1745
		[WrappingFieldAttribute(下标 = 4, 长度 = 2)]
		public ushort 铭文位二;
	}
}
