using System;

namespace GameServer.Networking
{
	// Token: 0x02000245 RID: 581
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1006, 长度 = 6, 注释 = "删除角色回应")]
	public sealed class 删除角色应答 : GamePacket
	{
		// Token: 0x06000330 RID: 816 RVA: 0x0000344A File Offset: 0x0000164A
		public 删除角色应答()
		{
			
			
		}

		// Token: 0x0400079F RID: 1951
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 角色编号;
	}
}
