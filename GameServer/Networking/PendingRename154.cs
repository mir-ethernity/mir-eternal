using System;

namespace GameServer.Networking
{
	// Token: 0x02000134 RID: 308
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 35, 长度 = 0, 注释 = "同步角色装备")]
	public sealed class 同步角色装备 : GamePacket
	{
		// Token: 0x0600021D RID: 541 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步角色装备()
		{
			
			
		}

		// Token: 0x0400059F RID: 1439
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040005A0 RID: 1440
		[WrappingFieldAttribute(下标 = 40, 长度 = 1)]
		public byte 装备数量;

		// Token: 0x040005A1 RID: 1441
		[WrappingFieldAttribute(下标 = 41, 长度 = 0)]
		public byte[] 字节描述;
	}
}
