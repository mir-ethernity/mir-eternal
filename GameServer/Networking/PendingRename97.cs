using System;

namespace GameServer.Networking
{
	// Token: 0x02000136 RID: 310
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 40, 长度 = 2, 注释 = "离开场景(包括商店/随机卷)")]
	public sealed class 玩家离开场景 : GamePacket
	{
		// Token: 0x0600021F RID: 543 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家离开场景()
		{
			
			
		}
	}
}
