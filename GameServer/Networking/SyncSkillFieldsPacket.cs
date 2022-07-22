using System;

namespace GameServer.Networking
{
	// Token: 0x0200012D RID: 301
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 19, 长度 = 0, 注释 = "SyncSkillFieldsPacket")]
	public sealed class SyncSkillFieldsPacket : GamePacket
	{
		// Token: 0x06000216 RID: 534 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncSkillFieldsPacket()
		{
			
			
		}

		// Token: 0x04000596 RID: 1430
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 栏位描述;
	}
}
