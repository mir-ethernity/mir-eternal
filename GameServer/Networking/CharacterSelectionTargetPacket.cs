using System;

namespace GameServer.Networking
{
	// Token: 0x02000070 RID: 112
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 31, 长度 = 6, 注释 = "CharacterSelectionTargetPacket")]
	public sealed class CharacterSelectionTargetPacket : GamePacket
	{
		// Token: 0x06000157 RID: 343 RVA: 0x0000344A File Offset: 0x0000164A
		public CharacterSelectionTargetPacket()
		{
			
			
		}

		// Token: 0x04000491 RID: 1169
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
