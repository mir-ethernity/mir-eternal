using System;

namespace GameServer.Networking
{
	// Token: 0x02000231 RID: 561
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 657, 长度 = 0, 注释 = "RequestTreasureDataPacket")]
	public sealed class 同步珍宝数据 : GamePacket
	{
		// Token: 0x0600031A RID: 794 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步珍宝数据()
		{
			
			
		}

		// Token: 0x0400078F RID: 1935
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 版本编号;

		// Token: 0x04000790 RID: 1936
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int 商品数量;

		// Token: 0x04000791 RID: 1937
		[WrappingFieldAttribute(下标 = 12, 长度 = 0)]
		public byte[] 商店数据;
	}
}
