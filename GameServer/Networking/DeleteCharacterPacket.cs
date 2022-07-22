using System;

namespace GameServer.Networking
{
	// Token: 0x02000247 RID: 583
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1008, 长度 = 6, 注释 = "DeleteCharacterPacket回应")]
	public sealed class DeleteCharacterPacket : GamePacket
	{
		// Token: 0x06000332 RID: 818 RVA: 0x0000344A File Offset: 0x0000164A
		public DeleteCharacterPacket()
		{
			
			
		}

		// Token: 0x040007A1 RID: 1953
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 角色编号;
	}
}
