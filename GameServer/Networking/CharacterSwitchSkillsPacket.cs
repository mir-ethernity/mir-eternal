using System;

namespace GameServer.Networking
{
	// Token: 0x02000072 RID: 114
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 33, 长度 = 4, 注释 = "CharacterSwitchSkillsPacket")]
	public sealed class CharacterSwitchSkillsPacket : GamePacket
	{
		// Token: 0x06000159 RID: 345 RVA: 0x0000344A File Offset: 0x0000164A
		public CharacterSwitchSkillsPacket()
		{
			
			
		}

		// Token: 0x04000492 RID: 1170
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort 技能编号;
	}
}
