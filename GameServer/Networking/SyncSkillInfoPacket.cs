using System;

namespace GameServer.Networking
{
	// Token: 0x0200012C RID: 300
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 18, 长度 = 0, 注释 = "SyncSkillInfoPacket")]
	public sealed class SyncSkillInfoPacket : GamePacket
	{
		// Token: 0x06000215 RID: 533 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncSkillInfoPacket()
		{
			
			
		}

		// Token: 0x04000595 RID: 1429
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 技能描述;
	}
}
