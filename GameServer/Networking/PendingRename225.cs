using System;

namespace GameServer.Networking
{
	// Token: 0x0200015E RID: 350
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 95, 长度 = 0, 注释 = "触发技能扩展(技能信息,目标,反馈,耗时)")]
	public sealed class 触发技能扩展 : GamePacket
	{
		// Token: 0x06000247 RID: 583 RVA: 0x0000344A File Offset: 0x0000164A
		public 触发技能扩展()
		{
			
			
		}

		// Token: 0x0400061C RID: 1564
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 对象编号;

		// Token: 0x0400061D RID: 1565
		[WrappingFieldAttribute(下标 = 8, 长度 = 2)]
		public ushort 技能编号;

		// Token: 0x0400061E RID: 1566
		[WrappingFieldAttribute(下标 = 10, 长度 = 1)]
		public byte 技能等级;

		// Token: 0x0400061F RID: 1567
		[WrappingFieldAttribute(下标 = 11, 长度 = 1)]
		public byte 技能铭文;

		// Token: 0x04000620 RID: 1568
		[WrappingFieldAttribute(下标 = 12, 长度 = 1)]
		public byte 动作编号;

		// Token: 0x04000621 RID: 1569
		[WrappingFieldAttribute(下标 = 13, 长度 = 1)]
		public byte 技能分段;

		// Token: 0x04000622 RID: 1570
		[WrappingFieldAttribute(下标 = 14, 长度 = 1)]
		public byte 未知参数;

		// Token: 0x04000623 RID: 1571
		[WrappingFieldAttribute(下标 = 15, 长度 = 0)]
		public byte[] 命中描述;
	}
}
