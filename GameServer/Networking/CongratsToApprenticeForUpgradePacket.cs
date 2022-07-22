using System;

namespace GameServer.Networking
{
	// Token: 0x020000ED RID: 237
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 545, 长度 = 0, 注释 = "CongratsToApprenticeForUpgradePacket(已弃用)")]
	public sealed class CongratsToApprenticeForUpgradePacket : GamePacket
	{
		// Token: 0x060001D4 RID: 468 RVA: 0x0000344A File Offset: 0x0000164A
		public CongratsToApprenticeForUpgradePacket()
		{
			
			
		}

		// Token: 0x04000537 RID: 1335
		[WrappingFieldAttribute(下标 = 2, 长度 = 0)]
		public byte[] 字节数据;
	}
}
