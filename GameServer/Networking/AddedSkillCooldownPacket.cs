using System;

namespace GameServer.Networking
{
	// Token: 0x02000169 RID: 361
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 109, 长度 = 10, 注释 = "AddedSkillCooldownPacket")]
	public sealed class AddedSkillCooldownPacket : GamePacket
	{
		// Token: 0x06000252 RID: 594 RVA: 0x0000344A File Offset: 0x0000164A
		public AddedSkillCooldownPacket()
		{
			
			
		}

		// Token: 0x0400064A RID: 1610
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public int 冷却编号;

		// Token: 0x0400064B RID: 1611
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 冷却时间;
	}
}
