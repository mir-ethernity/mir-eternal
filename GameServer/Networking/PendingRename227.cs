using System;

namespace GameServer.Networking
{
	// Token: 0x02000160 RID: 352
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 97, 长度 = 28, 注释 = "触发命中特效(技能信息,目标,血量,反馈)")]
	public sealed class 触发命中特效 : GamePacket
	{
		// Token: 0x06000249 RID: 585 RVA: 0x0000344A File Offset: 0x0000164A
		public 触发命中特效()
		{
			
			
		}

		// Token: 0x0400062B RID: 1579
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x0400062C RID: 1580
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 技能编号;

		// Token: 0x0400062D RID: 1581
		[WrappingFieldAttribute(下标 = 8, 长度 = 1)]
		public byte 技能等级;

		// Token: 0x0400062E RID: 1582
		[WrappingFieldAttribute(下标 = 9, 长度 = 1)]
		public byte 技能铭文;

		// Token: 0x0400062F RID: 1583
		[WrappingFieldAttribute(下标 = 10, 长度 = 1)]
		public byte 动作编号;

		// Token: 0x04000630 RID: 1584
		[WrappingFieldAttribute(下标 = 13, 长度 = 4)]
		public int 目标编号;

		// Token: 0x04000631 RID: 1585
		[WrappingFieldAttribute(下标 = 17, 长度 = 4)]
		public int 技能伤害;

		// Token: 0x04000632 RID: 1586
		[WrappingFieldAttribute(下标 = 21, 长度 = 2)]
		public ushort 招架伤害;

		// Token: 0x04000633 RID: 1587
		[WrappingFieldAttribute(下标 = 25, 长度 = 2)]
		public ushort 技能反馈;
	}
}
