using System;

namespace GameServer.Networking
{
	// Token: 0x020001F9 RID: 505
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 582, 长度 = 48, 注释 = "查询行会名字")]
	public sealed class GuildNameAnswerPAcket : GamePacket
	{
		// Token: 0x060002E2 RID: 738 RVA: 0x0000344A File Offset: 0x0000164A
		public GuildNameAnswerPAcket()
		{
			
			
		}

		// Token: 0x0400074E RID: 1870
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 行会编号;

		// Token: 0x0400074F RID: 1871
		[WrappingFieldAttribute(下标 = 6, 长度 = 25)]
		public string 行会名字;

		// Token: 0x04000750 RID: 1872
		[WrappingFieldAttribute(下标 = 31, 长度 = 4)]
		public int 会长编号;

		// Token: 0x04000751 RID: 1873
		[WrappingFieldAttribute(下标 = 35, 长度 = 4)]
		public DateTime 创建时间;

		// Token: 0x04000752 RID: 1874
		[WrappingFieldAttribute(下标 = 39, 长度 = 1)]
		public byte 行会人数;

		// Token: 0x04000753 RID: 1875
		[WrappingFieldAttribute(下标 = 40, 长度 = 1)]
		public byte 行会等级;
	}
}
