using System;

namespace GameServer.Networking
{
	// Token: 0x020001D1 RID: 465
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 534, 长度 = 38, 注释 = "OtherPersonPaysAttentionToHimselfPacket")]
	public sealed class OtherPersonPaysAttentionToHimselfPacket : GamePacket
	{
		// Token: 0x060002BA RID: 698 RVA: 0x0000344A File Offset: 0x0000164A
		public OtherPersonPaysAttentionToHimselfPacket()
		{
			
			
		}

		// Token: 0x04000726 RID: 1830
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x04000727 RID: 1831
		[WrappingFieldAttribute(下标 = 6, 长度 = 32)]
		public string 对象名字;
	}
}
