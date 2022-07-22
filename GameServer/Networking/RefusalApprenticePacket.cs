using System;

namespace GameServer.Networking
{
	// Token: 0x020001E3 RID: 483
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 553, 长度 = 6, 注释 = "RefusalApprenticePacket")]
	public sealed class RefusalApprenticePacket : GamePacket
	{
		// Token: 0x060002CC RID: 716 RVA: 0x0000344A File Offset: 0x0000164A
		public RefusalApprenticePacket()
		{
			
			
		}

		// Token: 0x04000737 RID: 1847
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
