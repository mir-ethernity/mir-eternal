using System;

namespace GameServer.Networking
{
	// Token: 0x02000114 RID: 276
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 600, 长度 = 42, 注释 = "购买珍宝商品")]
	public sealed class 购买珍宝商品 : GamePacket
	{
		// Token: 0x060001FB RID: 507 RVA: 0x0000344A File Offset: 0x0000164A
		public 购买珍宝商品()
		{
			
			
		}

		// Token: 0x04000567 RID: 1383
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 物品编号;

		// Token: 0x04000568 RID: 1384
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 购买数量;
	}
}
