using System;

namespace GameServer.Networking
{
	// Token: 0x020000DE RID: 222
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 527, 长度 = 6, 注释 = "添加仇人")]
	public sealed class 玩家添加仇人 : GamePacket
	{
		// Token: 0x060001C5 RID: 453 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家添加仇人()
		{
			
			
		}

		// Token: 0x0400052D RID: 1325
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
