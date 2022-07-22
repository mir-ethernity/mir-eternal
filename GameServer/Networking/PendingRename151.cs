using System;

namespace GameServer.Networking
{
	// Token: 0x02000182 RID: 386
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 138, 长度 = 13, 注释 = "同步角色外形")]
	public sealed class 同步角色外形 : GamePacket
	{
		// Token: 0x0600026B RID: 619 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步角色外形()
		{
			
			
		}

		// Token: 0x0400068E RID: 1678
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x0400068F RID: 1679
		[WrappingFieldAttribute(下标 = 7, 长度 = 1)]
		public byte 装备部位;

		// Token: 0x04000690 RID: 1680
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int 装备编号;

		// Token: 0x04000691 RID: 1681
		[WrappingFieldAttribute(下标 = 12, 长度 = 1)]
		public byte 升级次数;
	}
}
