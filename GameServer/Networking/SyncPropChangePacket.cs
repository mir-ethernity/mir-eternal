using System;

namespace GameServer.Networking
{
	// Token: 0x02000150 RID: 336
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 77, 长度 = 7, 注释 = "SyncPropChangePacket")]
	public sealed class SyncPropChangePacket : GamePacket
	{
		// Token: 0x06000239 RID: 569 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncPropChangePacket()
		{
			
			
		}

		// Token: 0x040005FB RID: 1531
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 属性编号;

		// Token: 0x040005FC RID: 1532
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 属性数值;
	}
}
