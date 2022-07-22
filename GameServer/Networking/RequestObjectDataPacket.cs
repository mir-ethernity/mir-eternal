using System;

namespace GameServer.Networking
{
	// Token: 0x02000069 RID: 105
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 19, 长度 = 10, 注释 = "RequestObjectDataPacket, 对应服务端0041封包")]
	public sealed class RequestObjectDataPacket : GamePacket
	{
		// Token: 0x06000150 RID: 336 RVA: 0x0000344A File Offset: 0x0000164A
		public RequestObjectDataPacket()
		{
			
			
		}

		// Token: 0x0400048A RID: 1162
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x0400048B RID: 1163
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 状态编号;
	}
}
