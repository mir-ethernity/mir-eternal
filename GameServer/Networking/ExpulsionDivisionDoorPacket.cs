using System;

namespace GameServer.Networking
{
	// Token: 0x020001EC RID: 492
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 566, 长度 = 6, 注释 = "ExpulsionDivisionDoorPacket")]
	public sealed class ExpulsionDivisionDoorPacket : GamePacket
	{
		// Token: 0x060002D5 RID: 725 RVA: 0x0000344A File Offset: 0x0000164A
		public ExpulsionDivisionDoorPacket()
		{
			
			
		}

		// Token: 0x04000742 RID: 1858
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
