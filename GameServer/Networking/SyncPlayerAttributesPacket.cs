using System;

namespace GameServer.Networking
{
	// Token: 0x02000133 RID: 307
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 34, 长度 = 0, 注释 = "SyncPlayerAttributesPacket")]
	public sealed class SyncPlayerAttributesPacket : GamePacket
	{
		// Token: 0x0600021C RID: 540 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncPlayerAttributesPacket()
		{
			
			
		}

		// Token: 0x0400059D RID: 1437
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 对象编号;

		// Token: 0x0400059E RID: 1438
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int 属性数量;
	}
}
