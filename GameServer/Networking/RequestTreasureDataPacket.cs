using System;

namespace GameServer.Networking
{
	// Token: 0x02000113 RID: 275
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 599, 长度 = 6, 注释 = "RequestTreasureDataPacket")]
	public sealed class RequestTreasureDataPacket : GamePacket
	{
		// Token: 0x060001FA RID: 506 RVA: 0x0000344A File Offset: 0x0000164A
		public RequestTreasureDataPacket()
		{
			
			
		}

		// Token: 0x04000566 RID: 1382
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 数据版本;
	}
}
