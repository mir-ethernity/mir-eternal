using System;

namespace GameServer.Networking
{
	// Token: 0x020000FF RID: 255
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 563, 长度 = 0, 注释 = "更改行会宣言")]
	public sealed class 更改行会宣言 : GamePacket
	{
		// Token: 0x060001E6 RID: 486 RVA: 0x0000344A File Offset: 0x0000164A
		public 更改行会宣言()
		{
			
			
		}

		// Token: 0x0400054A RID: 1354
		[WrappingFieldAttribute(下标 = 2, 长度 = 0)]
		public byte[] 行会宣言;
	}
}
