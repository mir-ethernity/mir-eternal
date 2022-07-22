using System;

namespace GameServer.Networking
{
	// Token: 0x02000162 RID: 354
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 99, 长度 = 5, 注释 = "释放完成, 可以释放下一个技能")]
	public sealed class 技能释放完成 : GamePacket
	{
		// Token: 0x0600024B RID: 587 RVA: 0x0000344A File Offset: 0x0000164A
		public 技能释放完成()
		{
			
			
		}

		// Token: 0x0400063A RID: 1594
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort 技能编号;

		// Token: 0x0400063B RID: 1595
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 动作编号;
	}
}
