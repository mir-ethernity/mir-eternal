using System;

namespace GameServer.Networking
{
	// Token: 0x02000178 RID: 376
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 127, 长度 = 7, 注释 = "SyncSkillLevelPacket数据")]
	public sealed class SyncSkillLevelPacket : GamePacket
	{
		// Token: 0x06000261 RID: 609 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncSkillLevelPacket()
		{
			
			
		}

		// Token: 0x0400067D RID: 1661
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort 技能编号;

		// Token: 0x0400067E RID: 1662
		[WrappingFieldAttribute(下标 = 4, 长度 = 2)]
		public ushort 当前经验;

		// Token: 0x0400067F RID: 1663
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 当前等级;
	}
}
