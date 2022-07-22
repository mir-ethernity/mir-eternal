using System;

namespace GameServer.Networking
{
	// Token: 0x02000161 RID: 353
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 98, 长度 = 13, 注释 = "技能释放中断")]
	public sealed class 技能释放中断 : GamePacket
	{
		// Token: 0x0600024A RID: 586 RVA: 0x0000344A File Offset: 0x0000164A
		public 技能释放中断()
		{
			
			
		}

		// Token: 0x04000634 RID: 1588
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x04000635 RID: 1589
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 技能编号;

		// Token: 0x04000636 RID: 1590
		[WrappingFieldAttribute(下标 = 8, 长度 = 1)]
		public byte 技能等级;

		// Token: 0x04000637 RID: 1591
		[WrappingFieldAttribute(下标 = 9, 长度 = 1)]
		public byte 技能铭文;

		// Token: 0x04000638 RID: 1592
		[WrappingFieldAttribute(下标 = 10, 长度 = 1)]
		public byte 动作编号;

		// Token: 0x04000639 RID: 1593
		[WrappingFieldAttribute(下标 = 11, 长度 = 1)]
		public byte 技能分段;
	}
}
