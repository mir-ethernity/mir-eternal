using System;

namespace GameServer.Networking
{
	// Token: 0x0200014C RID: 332
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 73, 长度 = 7, 注释 = "Npc变换类型")]
	public sealed class ObjectTransformTypePacket : GamePacket
	{
		// Token: 0x06000235 RID: 565 RVA: 0x0000344A File Offset: 0x0000164A
		public ObjectTransformTypePacket()
		{
			
			
		}

		// Token: 0x040005F0 RID: 1520
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040005F1 RID: 1521
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 改变类型;
	}
}
