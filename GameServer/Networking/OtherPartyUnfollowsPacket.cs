using System;

namespace GameServer.Networking
{
	// Token: 0x020001D2 RID: 466
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 535, 长度 = 38, 注释 = "OtherPartyUnfollowsPacket")]
	public sealed class OtherPartyUnfollowsPacket : GamePacket
	{
		// Token: 0x060002BB RID: 699 RVA: 0x0000344A File Offset: 0x0000164A
		public OtherPartyUnfollowsPacket()
		{
			
			
		}

		// Token: 0x04000728 RID: 1832
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x04000729 RID: 1833
		[WrappingFieldAttribute(下标 = 6, 长度 = 32)]
		public string 对象名字;
	}
}
