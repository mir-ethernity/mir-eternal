using System;

namespace GameServer.Networking
{
	// Token: 0x020001BF RID: 447
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 343, 长度 = 3, 注释 = "FixMaxPersistentPacket")]
	public sealed class FixMaxPersistentPacket : GamePacket
	{
		// Token: 0x060002A8 RID: 680 RVA: 0x0000344A File Offset: 0x0000164A
		public FixMaxPersistentPacket()
		{
			
			
		}

		// Token: 0x040006EA RID: 1770
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public bool 修复失败;
	}
}
