using System;

namespace GameServer.Networking
{
	// Token: 0x0200006A RID: 106
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 20, 长度 = 22, 注释 = "查看玩家装备, 右键头像查看资料时触发")]
	public sealed class 查看玩家装备 : GamePacket
	{
		// Token: 0x06000151 RID: 337 RVA: 0x0000344A File Offset: 0x0000164A
		public 查看玩家装备()
		{
			
			
		}

		// Token: 0x0400048C RID: 1164
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
