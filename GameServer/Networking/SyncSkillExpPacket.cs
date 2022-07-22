using System;

namespace GameServer.Networking
{
	// Token: 0x02000177 RID: 375
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 126, 长度 = 6, 注释 = "SyncSkillExpPacket")]
	public sealed class SyncSkillExpPacket : GamePacket
	{
		// Token: 0x06000260 RID: 608 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncSkillExpPacket()
		{
			
			
		}

		// Token: 0x0400067B RID: 1659
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort 技能编号;

		// Token: 0x0400067C RID: 1660
		[WrappingFieldAttribute(下标 = 4, 长度 = 2)]
		public ushort 当前经验;
	}
}
