using System;

namespace GameServer.Networking
{
	// Token: 0x0200013F RID: 319
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 56, 长度 = 7, 注释 = "角色复活")]
	public sealed class 玩家角色复活 : GamePacket
	{
		// Token: 0x06000228 RID: 552 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家角色复活()
		{
			
			
		}

		// Token: 0x040005BF RID: 1471
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040005C0 RID: 1472
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 复活方式;
	}
}
