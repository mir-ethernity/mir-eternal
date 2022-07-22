using System;

namespace GameServer.Networking
{
	// Token: 0x02000203 RID: 515
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 593, 长度 = 6, 注释 = "GuildRemoveMemberPacket")]
	public sealed class GuildRemoveMemberPacket : GamePacket
	{
		// Token: 0x060002EC RID: 748 RVA: 0x0000344A File Offset: 0x0000164A
		public GuildRemoveMemberPacket()
		{
			
			
		}

		// Token: 0x04000761 RID: 1889
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
