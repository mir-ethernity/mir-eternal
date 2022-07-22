using System;

namespace GameServer.Networking
{
	// Token: 0x020001CF RID: 463
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 532, 长度 = 39, 注释 = "添加关注")]
	public sealed class 玩家添加关注 : GamePacket
	{
		// Token: 0x060002B8 RID: 696 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家添加关注()
		{
			
			
		}

		// Token: 0x04000722 RID: 1826
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x04000723 RID: 1827
		[WrappingFieldAttribute(下标 = 6, 长度 = 32)]
		public string 对象名字;

		// Token: 0x04000724 RID: 1828
		[WrappingFieldAttribute(下标 = 38, 长度 = 1)]
		public bool 是否好友;
	}
}
