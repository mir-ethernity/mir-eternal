using System;

namespace GameServer.Networking
{
	// Token: 0x0200008A RID: 138
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 72, 长度 = 8, 注释 = "高级铭文洗练")]
	public sealed class 高级铭文洗练 : GamePacket
	{
		// Token: 0x06000171 RID: 369 RVA: 0x0000344A File Offset: 0x0000164A
		public 高级铭文洗练()
		{
			
			
		}

		// Token: 0x040004CA RID: 1226
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 装备类型;

		// Token: 0x040004CB RID: 1227
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 装备位置;

		// Token: 0x040004CC RID: 1228
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 物品编号;
	}
}
