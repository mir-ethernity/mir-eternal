using System;

namespace GameServer.Networking
{
	// Token: 0x020000A0 RID: 160
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 113, 长度 = 14, 注释 = "ClickNpcDialogPacket")]
	public sealed class ClickNpcDialogPacket : GamePacket
	{
		// Token: 0x06000187 RID: 391 RVA: 0x0000344A File Offset: 0x0000164A
		public ClickNpcDialogPacket()
		{
			
			
		}

		// Token: 0x040004F2 RID: 1266
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
