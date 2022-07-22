using System;

namespace GameServer.Networking
{
	// Token: 0x0200024A RID: 586
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1011, 长度 = 38, 注释 = "更改角色姓名")]
	public sealed class RoleRenamingAnswerPacket : GamePacket
	{
		// Token: 0x06000335 RID: 821 RVA: 0x0000344A File Offset: 0x0000164A
		public RoleRenamingAnswerPacket()
		{
			
			
		}
	}
}
