using System;

namespace GameServer.Networking
{
	// Token: 0x02000212 RID: 530
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 608, 长度 = 38, 注释 = "AddDiplomaticAnnouncementPacket")]
	public sealed class AddDiplomaticAnnouncementPacket : GamePacket
	{
		// Token: 0x060002FB RID: 763 RVA: 0x0000344A File Offset: 0x0000164A
		public AddDiplomaticAnnouncementPacket()
		{
			
			
		}

		// Token: 0x04000775 RID: 1909
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 外交类型;

		// Token: 0x04000776 RID: 1910
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 行会编号;

		// Token: 0x04000777 RID: 1911
		[WrappingFieldAttribute(下标 = 7, 长度 = 4)]
		public int 外交时间;

		// Token: 0x04000778 RID: 1912
		[WrappingFieldAttribute(下标 = 11, 长度 = 1)]
		public byte 行会等级;

		// Token: 0x04000779 RID: 1913
		[WrappingFieldAttribute(下标 = 12, 长度 = 1)]
		public byte 行会人数;

		// Token: 0x0400077A RID: 1914
		[WrappingFieldAttribute(下标 = 13, 长度 = 25)]
		public string 行会名字;
	}
}
