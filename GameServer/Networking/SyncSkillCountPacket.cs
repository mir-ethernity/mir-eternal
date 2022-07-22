using System;

namespace GameServer.Networking
{
	// Token: 0x020001C0 RID: 448
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 349, 长度 = 14, 注释 = "SyncSkillCountPacket")]
	public sealed class SyncSkillCountPacket : GamePacket
	{
		// Token: 0x060002A9 RID: 681 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncSkillCountPacket()
		{
			
			
		}

		// Token: 0x040006EB RID: 1771
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort 技能编号;

		// Token: 0x040006EC RID: 1772
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 技能计数;

		// Token: 0x040006ED RID: 1773
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public int 技能冷却;
	}
}
