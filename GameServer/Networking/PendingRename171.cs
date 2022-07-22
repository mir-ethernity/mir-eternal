using System;

namespace GameServer.Networking
{
	// Token: 0x020001C9 RID: 457
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 522, 长度 = 51, 注释 = "同步队员信息")]
	public sealed class 同步队员信息 : GamePacket
	{
		// Token: 0x060002B2 RID: 690 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步队员信息()
		{
			
			
		}

		// Token: 0x0400070A RID: 1802
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 队伍编号;

		// Token: 0x0400070B RID: 1803
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 对象编号;

		// Token: 0x0400070C RID: 1804
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public int 对象等级;

		// Token: 0x0400070D RID: 1805
		[WrappingFieldAttribute(下标 = 14, 长度 = 4)]
		public int 最大体力;

		// Token: 0x0400070E RID: 1806
		[WrappingFieldAttribute(下标 = 18, 长度 = 4)]
		public int 最大魔力;

		// Token: 0x0400070F RID: 1807
		[WrappingFieldAttribute(下标 = 22, 长度 = 4)]
		public int 当前体力;

		// Token: 0x04000710 RID: 1808
		[WrappingFieldAttribute(下标 = 26, 长度 = 4)]
		public int 当前魔力;

		// Token: 0x04000711 RID: 1809
		[WrappingFieldAttribute(下标 = 30, 长度 = 4)]
		public int 当前地图;

		// Token: 0x04000712 RID: 1810
		[WrappingFieldAttribute(下标 = 34, 长度 = 4)]
		public int 当前线路;

		// Token: 0x04000713 RID: 1811
		[WrappingFieldAttribute(下标 = 38, 长度 = 4)]
		public int 横向坐标;

		// Token: 0x04000714 RID: 1812
		[WrappingFieldAttribute(下标 = 42, 长度 = 4)]
		public int 纵向坐标;

		// Token: 0x04000715 RID: 1813
		[WrappingFieldAttribute(下标 = 46, 长度 = 4)]
		public int 坐标高度;

		// Token: 0x04000716 RID: 1814
		[WrappingFieldAttribute(下标 = 50, 长度 = 4)]
		public byte AttackMode;
	}
}
