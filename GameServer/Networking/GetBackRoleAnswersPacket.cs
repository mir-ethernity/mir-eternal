using System;

namespace GameServer.Networking
{
	// Token: 0x02000246 RID: 582
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1007, 长度 = 6, 注释 = "GetBackRoleCommand回应")]
	public sealed class GetBackRoleAnswersPacket : GamePacket
	{
		// Token: 0x06000331 RID: 817 RVA: 0x0000344A File Offset: 0x0000164A
		public GetBackRoleAnswersPacket()
		{
			
			
		}

		// Token: 0x040007A0 RID: 1952
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 角色编号;
	}
}
