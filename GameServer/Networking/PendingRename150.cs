using System;

namespace GameServer.Networking
{
	// Token: 0x02000142 RID: 322
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 61, 长度 = 0, 注释 = "同步角色列表, 适用于角色位移时同步视野")]
	public sealed class 同步角色列表 : GamePacket
	{
		// Token: 0x0600022B RID: 555 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步角色列表()
		{
			
			
		}
	}
}
