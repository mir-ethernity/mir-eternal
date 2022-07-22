using System;

namespace GameServer.Networking
{
	// Token: 0x020001C6 RID: 454
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 519, 长度 = 10, 注释 = "TeamMembersLeavePacket")]
	public sealed class TeamMembersLeavePacket : GamePacket
	{
		// Token: 0x060002AF RID: 687 RVA: 0x0000344A File Offset: 0x0000164A
		public TeamMembersLeavePacket()
		{
			
			
		}

		// Token: 0x040006FF RID: 1791
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 队伍编号;

		// Token: 0x04000700 RID: 1792
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 对象编号;
	}
}
