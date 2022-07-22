using System;

namespace GameServer.Networking
{
	// Token: 0x02000237 RID: 567
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 663, 长度 = 6, 注释 = "GuildSiegeRegistrationPacket")]
	public sealed class GuildSiegeRegistrationPacket : GamePacket
	{
		// Token: 0x06000320 RID: 800 RVA: 0x0000344A File Offset: 0x0000164A
		public GuildSiegeRegistrationPacket()
		{
			
			
		}

		// Token: 0x04000796 RID: 1942
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 行会编号;
	}
}
