using System;

namespace GameServer.Networking
{
	// Token: 0x02000179 RID: 377
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 128, 长度 = 0, 注释 = "物品变动")]
	public sealed class 玩家物品变动 : GamePacket
	{
		// Token: 0x06000262 RID: 610 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家物品变动()
		{
			
			
		}

		// Token: 0x04000680 RID: 1664
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 物品描述;
	}
}
