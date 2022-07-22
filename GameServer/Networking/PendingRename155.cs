using System;

namespace GameServer.Networking
{
	// Token: 0x020001C1 RID: 449
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 513, 长度 = 66, 注释 = "同步角色信息")]
	public sealed class 同步角色信息 : GamePacket
	{
		// Token: 0x060002AA RID: 682 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步角色信息()
		{
			
			
		}

		// Token: 0x040006EE RID: 1774
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040006EF RID: 1775
		[WrappingFieldAttribute(下标 = 6, 长度 = 32)]
		public string 对象名字;

		// Token: 0x040006F0 RID: 1776
		[WrappingFieldAttribute(下标 = 38, 长度 = 1)]
		public byte 对象职业;

		// Token: 0x040006F1 RID: 1777
		[WrappingFieldAttribute(下标 = 39, 长度 = 1)]
		public byte 对象性别;

		// Token: 0x040006F2 RID: 1778
		[WrappingFieldAttribute(下标 = 40, 长度 = 1)]
		public byte 会员等级;

		// Token: 0x040006F3 RID: 1779
		[WrappingFieldAttribute(下标 = 41, 长度 = 25)]
		public string 行会名字;
	}
}
