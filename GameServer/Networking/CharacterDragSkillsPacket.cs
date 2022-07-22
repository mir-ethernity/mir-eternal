using System;

namespace GameServer.Networking
{
	// Token: 0x02000163 RID: 355
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 100, 长度 = 7, 注释 = "CharacterDragSkillsPacket")]
	public sealed class CharacterDragSkillsPacket : GamePacket
	{
		// Token: 0x0600024C RID: 588 RVA: 0x0000344A File Offset: 0x0000164A
		public CharacterDragSkillsPacket()
		{
			
			
		}

		// Token: 0x0400063C RID: 1596
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 技能栏位;

		// Token: 0x0400063D RID: 1597
		[WrappingFieldAttribute(下标 = 3, 长度 = 2)]
		public ushort 技能编号;

		// Token: 0x0400063E RID: 1598
		[WrappingFieldAttribute(下标 = 5, 长度 = 1)]
		public byte 铭文编号;

		// Token: 0x0400063F RID: 1599
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 技能等级;
	}
}
