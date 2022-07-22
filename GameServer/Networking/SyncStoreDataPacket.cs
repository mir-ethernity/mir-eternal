using System;

namespace GameServer.Networking
{
	// Token: 0x02000184 RID: 388
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 142, 长度 = 0, 注释 = "同步商店版本")]
	public sealed class SyncStoreDataPacket : GamePacket
	{
		// Token: 0x0600026D RID: 621 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncStoreDataPacket()
		{
			
			
		}

		// Token: 0x04000693 RID: 1683
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 版本编号;

		// Token: 0x04000694 RID: 1684
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int 商品数量;

		// Token: 0x04000695 RID: 1685
		[WrappingFieldAttribute(下标 = 12, 长度 = 0)]
		public byte[] 文件内容;
	}
}
