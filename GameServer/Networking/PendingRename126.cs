using System;

namespace GameServer.Networking
{
	// Token: 0x0200017C RID: 380
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 132, 长度 = 0, 注释 = "玩家掉落装备")]
	public sealed class 玩家掉落装备 : GamePacket
	{
		// Token: 0x06000265 RID: 613 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家掉落装备()
		{
			
			
		}

		// Token: 0x04000687 RID: 1671
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public byte[] 物品描述;
	}
}
