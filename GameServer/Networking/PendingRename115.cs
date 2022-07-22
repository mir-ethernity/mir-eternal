using System;

namespace GameServer.Networking
{
	// Token: 0x02000086 RID: 134
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 68, 长度 = 7, 注释 = "玩家镶嵌灵石")]
	public sealed class 玩家镶嵌灵石 : GamePacket
	{
		// Token: 0x0600016D RID: 365 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家镶嵌灵石()
		{
			
			
		}

		// Token: 0x040004BB RID: 1211
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 装备类型;

		// Token: 0x040004BC RID: 1212
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 装备位置;

		// Token: 0x040004BD RID: 1213
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 装备孔位;

		// Token: 0x040004BE RID: 1214
		[WrappingFieldAttribute(下标 = 5, 长度 = 1)]
		public byte 灵石类型;

		// Token: 0x040004BF RID: 1215
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 灵石位置;
	}
}
