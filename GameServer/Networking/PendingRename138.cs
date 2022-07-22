using System;

namespace GameServer.Networking
{
	// Token: 0x02000172 RID: 370
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 121, 长度 = 10, 注释 = "CharacterSelectionTargetPacket")]
	public sealed class 玩家选中目标 : GamePacket
	{
		// Token: 0x0600025B RID: 603 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家选中目标()
		{
			
			
		}

		// Token: 0x04000663 RID: 1635
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 角色编号;

		// Token: 0x04000664 RID: 1636
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 目标编号;
	}
}
