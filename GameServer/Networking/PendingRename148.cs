using System;
using System.Drawing;

namespace GameServer.Networking
{
	// Token: 0x02000128 RID: 296
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 12, 长度 = 171, 注释 = "同步CharacterData(地图.坐标.职业.性别.等级...)")]
	public sealed class 同步CharacterData : GamePacket
	{
		// Token: 0x06000211 RID: 529 RVA: 0x00003468 File Offset: 0x00001668
		public 同步CharacterData()
		{
			
			this.经验上限 = 2000000000;
			
		}

		// Token: 0x0400057E RID: 1406
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x0400057F RID: 1407
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 当前地图;

		// Token: 0x04000580 RID: 1408
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public int 当前线路;

		// Token: 0x04000581 RID: 1409
		[WrappingFieldAttribute(下标 = 14, 长度 = 1)]
		public byte 对象职业;

		// Token: 0x04000582 RID: 1410
		[WrappingFieldAttribute(下标 = 15, 长度 = 1)]
		public byte 对象性别;

		// Token: 0x04000583 RID: 1411
		[WrappingFieldAttribute(下标 = 16, 长度 = 1)]
		public byte 对象等级;

		// Token: 0x04000584 RID: 1412
		[WrappingFieldAttribute(下标 = 62, 长度 = 4)]
		public Point 对象坐标;

		// Token: 0x04000585 RID: 1413
		[WrappingFieldAttribute(下标 = 66, 长度 = 2)]
		public ushort 对象高度;

		// Token: 0x04000586 RID: 1414
		[WrappingFieldAttribute(下标 = 68, 长度 = 2)]
		public ushort 对象朝向;

		// Token: 0x04000587 RID: 1415
		[WrappingFieldAttribute(下标 = 71, 长度 = 4)]
		public int 所需经验;

		// Token: 0x04000588 RID: 1416
		[WrappingFieldAttribute(下标 = 83, 长度 = 4)]
		public int 经验上限;

		// Token: 0x04000589 RID: 1417
		[WrappingFieldAttribute(下标 = 87, 长度 = 4)]
		public int 双倍经验;

		// Token: 0x0400058A RID: 1418
		[WrappingFieldAttribute(下标 = 95, 长度 = 4)]
		public int PK值惩罚;

		// Token: 0x0400058B RID: 1419
		[WrappingFieldAttribute(下标 = 99, 长度 = 1)]
		public byte AttackMode;

		// Token: 0x0400058C RID: 1420
		[WrappingFieldAttribute(下标 = 116, 长度 = 4)]
		public int 当前时间;

		// Token: 0x0400058D RID: 1421
		[WrappingFieldAttribute(下标 = 134, 长度 = 2)]
		public ushort OpenLevelCommand;

		// Token: 0x0400058E RID: 1422
		[WrappingFieldAttribute(下标 = 144, 长度 = 4)]
		public int 当前经验;

		// Token: 0x0400058F RID: 1423
		[WrappingFieldAttribute(下标 = 169, 长度 = 2)]
		public ushort 特修折扣;
	}
}
