using System;

namespace GameServer.Networking
{
	// Token: 0x0200013D RID: 317
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 50, 长度 = 10, 注释 = "对象转动")]
	public sealed class ObjectRotationDirectionPacket : GamePacket
	{
		// Token: 0x06000226 RID: 550 RVA: 0x0000344A File Offset: 0x0000164A
		public ObjectRotationDirectionPacket()
		{
			
			
		}

		// Token: 0x040005BB RID: 1467
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040005BC RID: 1468
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 转向耗时;

		// Token: 0x040005BD RID: 1469
		[WrappingFieldAttribute(下标 = 8, 长度 = 2)]
		public ushort 对象朝向;
	}
}
