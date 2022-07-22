using System;

namespace GameServer.Networking
{
	// Token: 0x02000122 RID: 290
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 1006, 长度 = 6, 注释 = "进入游戏")]
	public sealed class 客户进入游戏 : GamePacket
	{
		// Token: 0x0600020B RID: 523 RVA: 0x0000344A File Offset: 0x0000164A
		public 客户进入游戏()
		{
			
			
		}

		// Token: 0x04000578 RID: 1400
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 角色编号;
	}
}
