using System;

namespace GameServer.Networking
{
	// Token: 0x020001B0 RID: 432
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 279, 长度 = 4, 注释 = "更换角色计时")]
	public sealed class 更换角色计时 : GamePacket
	{
		// Token: 0x06000299 RID: 665 RVA: 0x0000344A File Offset: 0x0000164A
		public 更换角色计时()
		{
			
			
		}

		// Token: 0x040006E2 RID: 1762
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public bool 成功;
	}
}
