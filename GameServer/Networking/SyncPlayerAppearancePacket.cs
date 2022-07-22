using System;

namespace GameServer.Networking
{
	// Token: 0x02000144 RID: 324
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 64, 长度 = 129, 注释 = "SyncPlayerAppearancePacket")]
	public sealed class SyncPlayerAppearancePacket : GamePacket
	{
		// Token: 0x0600022D RID: 557 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncPlayerAppearancePacket()
		{
			
			
		}

		// Token: 0x040005CC RID: 1484
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040005CD RID: 1485
		[WrappingFieldAttribute(下标 = 7, 长度 = 1)]
		public byte 对象职业;

		// Token: 0x040005CE RID: 1486
		[WrappingFieldAttribute(下标 = 8, 长度 = 1)]
		public byte 对象性别;

		// Token: 0x040005CF RID: 1487
		[WrappingFieldAttribute(下标 = 9, 长度 = 1)]
		public byte 对象发型;

		// Token: 0x040005D0 RID: 1488
		[WrappingFieldAttribute(下标 = 10, 长度 = 1)]
		public byte 对象发色;

		// Token: 0x040005D1 RID: 1489
		[WrappingFieldAttribute(下标 = 11, 长度 = 1)]
		public byte 对象脸型;

		// Token: 0x040005D2 RID: 1490
		[WrappingFieldAttribute(下标 = 14, 长度 = 1)]
		public int 对象PK值;

		// Token: 0x040005D3 RID: 1491
		[WrappingFieldAttribute(下标 = 19, 长度 = 1)]
		public byte 武器等级;

		// Token: 0x040005D4 RID: 1492
		[WrappingFieldAttribute(下标 = 20, 长度 = 4)]
		public int 身上武器;

		// Token: 0x040005D5 RID: 1493
		[WrappingFieldAttribute(下标 = 24, 长度 = 4)]
		public int 身上衣服;

		// Token: 0x040005D6 RID: 1494
		[WrappingFieldAttribute(下标 = 28, 长度 = 4)]
		public int 身上披风;

		// Token: 0x040005D7 RID: 1495
		[WrappingFieldAttribute(下标 = 32, 长度 = 4)]
		public int 当前体力;

		// Token: 0x040005D8 RID: 1496
		[WrappingFieldAttribute(下标 = 36, 长度 = 4)]
		public int 当前魔力;

		// Token: 0x040005D9 RID: 1497
		[WrappingFieldAttribute(下标 = 46, 长度 = 4)]
		public int 外观时间;

		// Token: 0x040005DA RID: 1498
		[WrappingFieldAttribute(下标 = 50, 长度 = 1)]
		public byte 摆摊状态;

		// Token: 0x040005DB RID: 1499
		[WrappingFieldAttribute(下标 = 51, 长度 = 0)]
		public string 摊位名字;

		// Token: 0x040005DC RID: 1500
		[WrappingFieldAttribute(下标 = 84, 长度 = 45)]
		public string 对象名字;

		// Token: 0x040005DD RID: 1501
		[WrappingFieldAttribute(下标 = 118, 长度 = 4)]
		public int 行会编号;
	}
}
