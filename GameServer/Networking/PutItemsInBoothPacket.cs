using System;

namespace GameServer.Networking
{
	// Token: 0x0200009A RID: 154
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 107, 长度 = 11, 注释 = "PutItemsInBoothPacket")]
	public sealed class PutItemsInBoothPacket : GamePacket
	{
		// Token: 0x06000181 RID: 385 RVA: 0x0000344A File Offset: 0x0000164A
		public PutItemsInBoothPacket()
		{
			
			
		}

		// Token: 0x040004E6 RID: 1254
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 放入位置;

		// Token: 0x040004E7 RID: 1255
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 物品容器;

		// Token: 0x040004E8 RID: 1256
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 物品位置;

		// Token: 0x040004E9 RID: 1257
		[WrappingFieldAttribute(下标 = 5, 长度 = 2)]
		public ushort 物品数量;

		// Token: 0x040004EA RID: 1258
		[WrappingFieldAttribute(下标 = 7, 长度 = 1)]
		public int 物品价格;
	}
}
