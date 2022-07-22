using System;

namespace GameServer.Networking
{
	// Token: 0x0200017F RID: 383
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 135, 长度 = 0, 注释 = "拾取物品")]
	public sealed class 玩家拾取物品 : GamePacket
	{
		// Token: 0x06000268 RID: 616 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家拾取物品()
		{
			
			
		}

		// Token: 0x04000689 RID: 1673
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 角色编号;

		// Token: 0x0400068A RID: 1674
		[WrappingFieldAttribute(下标 = 17, 长度 = 4)]
		public byte[] 物品描述;
	}
}
