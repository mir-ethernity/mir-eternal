using System;

namespace GameServer.Networking
{
	// Token: 0x02000083 RID: 131
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 57, 长度 = 4, 注释 = "玩家扩展背包")]
	public sealed class 玩家扩展背包 : GamePacket
	{
		// Token: 0x0600016A RID: 362 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家扩展背包()
		{
			
			
		}

		// Token: 0x040004B7 RID: 1207
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 背包类型;

		// Token: 0x040004B8 RID: 1208
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 扩展大小;
	}
}
