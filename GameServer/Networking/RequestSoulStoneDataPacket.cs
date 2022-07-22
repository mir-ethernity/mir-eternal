using System;

namespace GameServer.Networking
{
	// Token: 0x020000CA RID: 202
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 231, 长度 = 6, 注释 = "RequestSoulStoneDataPacket")]
	public sealed class RequestSoulStoneDataPacket : GamePacket
	{
		// Token: 0x060001B1 RID: 433 RVA: 0x0000344A File Offset: 0x0000164A
		public RequestSoulStoneDataPacket()
		{
			
			
		}

		// Token: 0x0400051A RID: 1306
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
