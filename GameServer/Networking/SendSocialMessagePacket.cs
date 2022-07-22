using System;

namespace GameServer.Networking
{
	// Token: 0x020000E0 RID: 224
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 529, 长度 = 0, 注释 = "SendChatMessagePacket(公会/队伍/私人)")]
	public sealed class SendSocialMessagePacket : GamePacket
	{
		// Token: 0x060001C7 RID: 455 RVA: 0x0000344A File Offset: 0x0000164A
		public SendSocialMessagePacket()
		{
			
			
		}

		// Token: 0x0400052F RID: 1327
		[WrappingFieldAttribute(下标 = 2, 长度 = 0)]
		public byte[] 字节数据;
	}
}
