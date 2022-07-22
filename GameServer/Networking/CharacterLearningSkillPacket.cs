using System;

namespace GameServer.Networking
{
	// Token: 0x0200015B RID: 347
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 89, 长度 = 9, 注释 = "CharacterLearningSkillPacket")]
	public sealed class CharacterLearningSkillPacket : GamePacket
	{
		// Token: 0x06000244 RID: 580 RVA: 0x0000344A File Offset: 0x0000164A
		public CharacterLearningSkillPacket()
		{
			
			
		}

		// Token: 0x04000610 RID: 1552
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 角色编号;

		// Token: 0x04000611 RID: 1553
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 技能编号;
	}
}
