using System;

namespace GameServer.Networking
{
	// Token: 0x02000202 RID: 514
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 592, 长度 = 54, 注释 = "GuildJoinMemberPacket")]
	public sealed class GuildJoinMemberPacket : GamePacket
	{
		// Token: 0x060002EB RID: 747 RVA: 0x0000344A File Offset: 0x0000164A
		public GuildJoinMemberPacket()
		{
			
			
		}

		// Token: 0x0400075B RID: 1883
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x0400075C RID: 1884
		[WrappingFieldAttribute(下标 = 6, 长度 = 32)]
		public string 对象名字;

		// Token: 0x0400075D RID: 1885
		[WrappingFieldAttribute(下标 = 38, 长度 = 1)]
		public byte 对象职位;

		// Token: 0x0400075E RID: 1886
		[WrappingFieldAttribute(下标 = 39, 长度 = 1)]
		public byte 对象等级;

		// Token: 0x0400075F RID: 1887
		[WrappingFieldAttribute(下标 = 40, 长度 = 1)]
		public byte 对象职业;

		// Token: 0x04000760 RID: 1888
		[WrappingFieldAttribute(下标 = 41, 长度 = 1)]
		public byte 当前地图;
	}
}
