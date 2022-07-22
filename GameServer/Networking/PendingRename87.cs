using System;

namespace GameServer.Networking
{
	// Token: 0x02000176 RID: 374
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 125, 长度 = 5, 注释 = "技能升级")]
	public sealed class 玩家技能升级 : GamePacket
	{
		// Token: 0x0600025F RID: 607 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家技能升级()
		{
			
			
		}

		// Token: 0x04000679 RID: 1657
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort 技能编号;

		// Token: 0x0400067A RID: 1658
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 技能等级;
	}
}
