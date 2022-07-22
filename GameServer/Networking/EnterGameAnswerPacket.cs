using System;

namespace GameServer.Networking
{
	// Token: 0x02000242 RID: 578
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1003, 长度 = 6, 注释 = "回应客户端进入游戏请求")]
	public sealed class EnterGameAnswerPacket : GamePacket
	{
		// Token: 0x0600032D RID: 813 RVA: 0x0000344A File Offset: 0x0000164A
		public EnterGameAnswerPacket()
		{
			
			
		}

		// Token: 0x0400079C RID: 1948
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 角色编号;
	}
}
