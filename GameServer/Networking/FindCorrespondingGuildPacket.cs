using System;

namespace GameServer.Networking
{
	// Token: 0x020000F7 RID: 247
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 555, 长度 = 31, 注释 = "FindCorrespondingGuildPacket")]
	public sealed class FindCorrespondingGuildPacket : GamePacket
	{
		// Token: 0x060001DE RID: 478 RVA: 0x0000344A File Offset: 0x0000164A
		public FindCorrespondingGuildPacket()
		{
			
			
		}

		// Token: 0x04000540 RID: 1344
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 行会编号;

		// Token: 0x04000541 RID: 1345
		[WrappingFieldAttribute(下标 = 6, 长度 = 25)]
		public string 行会名字;
	}
}
