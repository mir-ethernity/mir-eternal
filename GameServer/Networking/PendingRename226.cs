using System;

namespace GameServer.Networking
{
	// Token: 0x0200015F RID: 351
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 96, 长度 = 0, 注释 = "触发技能正常(技能信息,目标,反馈,耗时)")]
	public sealed class 触发技能正常 : GamePacket
	{
		// Token: 0x06000248 RID: 584 RVA: 0x00003504 File Offset: 0x00001704
		public 触发技能正常()
		{
			
			this.技能分段 = 1;
			this.命中描述 = new byte[1];
			
		}

		// Token: 0x04000624 RID: 1572
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 对象编号;

		// Token: 0x04000625 RID: 1573
		[WrappingFieldAttribute(下标 = 8, 长度 = 2)]
		public ushort 技能编号;

		// Token: 0x04000626 RID: 1574
		[WrappingFieldAttribute(下标 = 10, 长度 = 1)]
		public byte 技能等级;

		// Token: 0x04000627 RID: 1575
		[WrappingFieldAttribute(下标 = 11, 长度 = 1)]
		public byte 技能铭文;

		// Token: 0x04000628 RID: 1576
		[WrappingFieldAttribute(下标 = 12, 长度 = 1)]
		public byte 动作编号;

		// Token: 0x04000629 RID: 1577
		[WrappingFieldAttribute(下标 = 13, 长度 = 1)]
		public byte 技能分段;

		// Token: 0x0400062A RID: 1578
		[WrappingFieldAttribute(下标 = 14, 长度 = 0)]
		public byte[] 命中描述;
	}
}
