using System;

namespace GameServer.Networking
{
	// Token: 0x020001C8 RID: 456
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 521, 长度 = 52, 注释 = "TeamStatusChangePacket")]
	public sealed class TeamStatusChangePacket : GamePacket
	{
		// Token: 0x060002B1 RID: 689 RVA: 0x0000344A File Offset: 0x0000164A
		public TeamStatusChangePacket()
		{
			
			
		}

		// Token: 0x04000705 RID: 1797
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 队伍编号;

		// Token: 0x04000706 RID: 1798
		[WrappingFieldAttribute(下标 = 6, 长度 = 32)]
		public string 队伍名字;

		// Token: 0x04000707 RID: 1799
		[WrappingFieldAttribute(下标 = 38, 长度 = 4)]
		public int 成员上限;

		// Token: 0x04000708 RID: 1800
		[WrappingFieldAttribute(下标 = 42, 长度 = 1)]
		public byte 分配方式;

		// Token: 0x04000709 RID: 1801
		[WrappingFieldAttribute(下标 = 44, 长度 = 4)]
		public int 队长编号;
	}
}
