using System;

namespace GameServer.Networking
{
	// Token: 0x02000232 RID: 562
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 658, 长度 = 10, 注释 = "购买珍宝商品")]
	public sealed class 购入珍宝商品 : GamePacket
	{
		// Token: 0x0600031B RID: 795 RVA: 0x0000344A File Offset: 0x0000164A
		public 购入珍宝商品()
		{
			
			
		}

		// Token: 0x04000792 RID: 1938
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 物品编号;

		// Token: 0x04000793 RID: 1939
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 购买数量;
	}
}
