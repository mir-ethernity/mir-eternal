using System;

namespace GameServer.Networking
{
	// Token: 0x02000146 RID: 326
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 66, 长度 = 58, 注释 = "同步Npcc数据扩展(宠物)")]
	public sealed class SyncExtendedDataPacket : GamePacket
	{
		// Token: 0x0600022F RID: 559 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncExtendedDataPacket()
		{
			
			
		}

		// Token: 0x040005E3 RID: 1507
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040005E4 RID: 1508
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 模板编号;

		// Token: 0x040005E5 RID: 1509
		[WrappingFieldAttribute(下标 = 10, 长度 = 1)]
		public byte 对象质量;

		// Token: 0x040005E6 RID: 1510
		[WrappingFieldAttribute(下标 = 11, 长度 = 1)]
		public byte 对象等级;

		// Token: 0x040005E7 RID: 1511
		[WrappingFieldAttribute(下标 = 12, 长度 = 4)]
		public int 最大体力;

		// Token: 0x040005E8 RID: 1512
		[WrappingFieldAttribute(下标 = 16, 长度 = 1)]
		public byte 对象类型;

		// Token: 0x040005E9 RID: 1513
		[WrappingFieldAttribute(下标 = 17, 长度 = 1)]
		public byte 当前等级;

		// Token: 0x040005EA RID: 1514
		[WrappingFieldAttribute(下标 = 18, 长度 = 4)]
		public int 主人编号;

		// Token: 0x040005EB RID: 1515
		[WrappingFieldAttribute(下标 = 22, 长度 = 36)]
		public string 主人名字;
	}
}
