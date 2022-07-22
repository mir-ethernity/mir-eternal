using System;

namespace GameServer.Networking
{
	// Token: 0x02000075 RID: 117
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 39, 长度 = 5, 注释 = "装备技能")]
	public sealed class CharacterEquipmentSkillsPacket : GamePacket
	{
		// Token: 0x0600015C RID: 348 RVA: 0x0000344A File Offset: 0x0000164A
		public CharacterEquipmentSkillsPacket()
		{
			
			
		}

		// Token: 0x04000499 RID: 1177
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 技能栏位;

		// Token: 0x0400049A RID: 1178
		[WrappingFieldAttribute(下标 = 3, 长度 = 2)]
		public ushort 技能编号;
	}
}
