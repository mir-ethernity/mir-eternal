using System;

namespace GameServer.Networking
{
	// Token: 0x020001C5 RID: 453
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 518, 长度 = 45, 注释 = "AddMembersToTeamPacket")]
	public sealed class AddMembersToTeamPacket : GamePacket
	{
		// Token: 0x060002AE RID: 686 RVA: 0x0000344A File Offset: 0x0000164A
		public AddMembersToTeamPacket()
		{
			
			
		}

		// Token: 0x040006F9 RID: 1785
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 队伍编号;

		// Token: 0x040006FA RID: 1786
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040006FB RID: 1787
		[WrappingFieldAttribute(下标 = 10, 长度 = 32)]
		public string 对象名字;

		// Token: 0x040006FC RID: 1788
		[WrappingFieldAttribute(下标 = 42, 长度 = 1)]
		public byte 对象性别;

		// Token: 0x040006FD RID: 1789
		[WrappingFieldAttribute(下标 = 43, 长度 = 1)]
		public byte 对象职业;

		// Token: 0x040006FE RID: 1790
		[WrappingFieldAttribute(下标 = 44, 长度 = 1)]
		public byte 在线离线;
	}
}
