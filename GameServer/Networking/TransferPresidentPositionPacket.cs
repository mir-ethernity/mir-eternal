using System;

namespace GameServer.Networking
{
	// Token: 0x02000103 RID: 259
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 567, 长度 = 6, 注释 = "TransferPresidentPositionPacket")]
	public sealed class TransferPresidentPositionPacket : GamePacket
	{
		// Token: 0x060001EA RID: 490 RVA: 0x0000344A File Offset: 0x0000164A
		public TransferPresidentPositionPacket()
		{
			
			
		}

		// Token: 0x04000550 RID: 1360
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
