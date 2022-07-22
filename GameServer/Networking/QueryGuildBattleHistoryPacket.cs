using System;

namespace GameServer.Networking
{
	// Token: 0x020000BE RID: 190
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 178, 长度 = 3, 注释 = "QueryGuildBattleHistoryPacket")]
	public sealed class QueryGuildBattleHistoryPacket : GamePacket
	{
		// Token: 0x060001A5 RID: 421 RVA: 0x0000344A File Offset: 0x0000164A
		public QueryGuildBattleHistoryPacket()
		{
			
			
		}

		// Token: 0x04000513 RID: 1299
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte PetMode;
	}
}
