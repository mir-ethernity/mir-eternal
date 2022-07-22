using System;
using System.Drawing;

namespace GameServer.Networking
{
	// Token: 0x02000073 RID: 115
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 34, 长度 = 16, 注释 = "释放技能")]
	public sealed class CharacterReleaseSkillsPacket : GamePacket
	{
		// Token: 0x0600015A RID: 346 RVA: 0x0000344A File Offset: 0x0000164A
		public CharacterReleaseSkillsPacket()
		{
			
			
		}

		// Token: 0x04000493 RID: 1171
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort 技能编号;

		// Token: 0x04000494 RID: 1172
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 动作编号;

		// Token: 0x04000495 RID: 1173
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 目标编号;

		// Token: 0x04000496 RID: 1174
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public Point 锚点坐标;

		// Token: 0x04000497 RID: 1175
		[WrappingFieldAttribute(下标 = 14, 长度 = 2)]
		public ushort 锚点高度;
	}
}
