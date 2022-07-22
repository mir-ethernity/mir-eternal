using System;

namespace GameServer.Networking
{
	// Token: 0x020001BD RID: 445
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 332, 长度 = 3, 注释 = "SyncMarfaPrivilegesPacket")]
	public sealed class SyncMarfaPrivilegesPacket : GamePacket
	{
		// Token: 0x060002A6 RID: 678 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncMarfaPrivilegesPacket()
		{
			
			
		}

		// Token: 0x040006E9 RID: 1769
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 玛法特权;
	}
}
