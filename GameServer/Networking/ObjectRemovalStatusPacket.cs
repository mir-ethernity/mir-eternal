using System;

namespace GameServer.Networking
{
	// Token: 0x0200016E RID: 366
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 117, 长度 = 10, 注释 = "移除BUFF")]
	public sealed class ObjectRemovalStatusPacket : GamePacket
	{
		// Token: 0x06000257 RID: 599 RVA: 0x0000344A File Offset: 0x0000164A
		public ObjectRemovalStatusPacket()
		{
			
			
		}

		// Token: 0x04000656 RID: 1622
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x04000657 RID: 1623
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int Buff索引;
	}
}
