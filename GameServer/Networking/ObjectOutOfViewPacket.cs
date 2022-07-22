using System;

namespace GameServer.Networking
{
	// Token: 0x02000143 RID: 323
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 62, 长度 = 7, 注释 = "对象消失")]
	public sealed class ObjectOutOfViewPacket : GamePacket
	{
		// Token: 0x0600022C RID: 556 RVA: 0x0000344A File Offset: 0x0000164A
		public ObjectOutOfViewPacket()
		{
			
			
		}

		// Token: 0x040005CA RID: 1482
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040005CB RID: 1483
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 消失方式;
	}
}
