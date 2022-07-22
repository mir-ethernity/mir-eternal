using System;

namespace GameServer.Networking
{
	// Token: 0x0200013E RID: 318
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 55, 长度 = 7, 注释 = "对象死亡")]
	public sealed class ObjectCharacterDiesPacket : GamePacket
	{
		// Token: 0x06000227 RID: 551 RVA: 0x0000344A File Offset: 0x0000164A
		public ObjectCharacterDiesPacket()
		{
			
			
		}

		// Token: 0x040005BE RID: 1470
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
