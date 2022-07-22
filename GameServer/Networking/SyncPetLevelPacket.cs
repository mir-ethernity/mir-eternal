using System;

namespace GameServer.Networking
{
	// Token: 0x0200014B RID: 331
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 72, 长度 = 7, 注释 = "SyncPetLevelPacket")]
	public sealed class SyncPetLevelPacket : GamePacket
	{
		// Token: 0x06000234 RID: 564 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncPetLevelPacket()
		{
			
			
		}

		// Token: 0x040005EE RID: 1518
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 宠物编号;

		// Token: 0x040005EF RID: 1519
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 宠物等级;
	}
}
