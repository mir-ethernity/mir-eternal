using System;

namespace GameServer.Networking
{
	// Token: 0x020000D9 RID: 217
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 522, 长度 = 38, 注释 = "AddFriendsToFollowPacket")]
	public sealed class AddFriendsToFollowPacket : GamePacket
	{
		// Token: 0x060001C0 RID: 448 RVA: 0x0000344A File Offset: 0x0000164A
		public AddFriendsToFollowPacket()
		{
			
			
		}

		// Token: 0x04000529 RID: 1321
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x0400052A RID: 1322
		[WrappingFieldAttribute(下标 = 6, 长度 = 32)]
		public string 对象名字;
	}
}
