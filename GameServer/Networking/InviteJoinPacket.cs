using System;

namespace GameServer.Networking
{
	// Token: 0x02000204 RID: 516
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 594, 长度 = 63, 注释 = "InviteJoinPacket")]
	public sealed class InviteJoinPacket : GamePacket
	{
		// Token: 0x060002ED RID: 749 RVA: 0x0000344A File Offset: 0x0000164A
		public InviteJoinPacket()
		{
			
			
		}

		// Token: 0x04000762 RID: 1890
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x04000763 RID: 1891
		[WrappingFieldAttribute(下标 = 6, 长度 = 32)]
		public string 对象名字;

		// Token: 0x04000764 RID: 1892
		[WrappingFieldAttribute(下标 = 38, 长度 = 25)]
		public string 行会名字;
	}
}
