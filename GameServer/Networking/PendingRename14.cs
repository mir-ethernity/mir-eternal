using System;

namespace GameServer.Networking
{
	// Token: 0x02000066 RID: 102
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 16, 长度 = 8, 注释 = "角色转动")]
	public sealed class 客户角色转动 : GamePacket
	{
		// Token: 0x0600014D RID: 333 RVA: 0x0000344A File Offset: 0x0000164A
		public 客户角色转动()
		{
			
			
		}

		// Token: 0x04000486 RID: 1158
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public short 转动方向;

		// Token: 0x04000487 RID: 1159
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public uint 转动耗时;
	}
}
