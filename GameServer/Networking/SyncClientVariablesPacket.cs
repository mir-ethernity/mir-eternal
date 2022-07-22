using System;

namespace GameServer.Networking
{
	// Token: 0x0200019A RID: 410
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 186, 长度 = 514, 注释 = "SyncClientVariablesPacket(物品快捷键)")]
	public sealed class SyncClientVariablesPacket : GamePacket
	{
		// Token: 0x06000283 RID: 643 RVA: 0x0000344A File Offset: 0x0000164A
		public SyncClientVariablesPacket()
		{
			
			
		}

		// Token: 0x040006B7 RID: 1719
		[WrappingFieldAttribute(下标 = 2, 长度 = 512)]
		public byte[] 字节数据;
	}
}
