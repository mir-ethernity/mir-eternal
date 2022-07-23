using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 529, 长度 = 0, 注释 = "SendChatMessagePacket(公会/队伍/私人)")]
	public sealed class SendSocialMessagePacket : GamePacket
	{
		
		public SendSocialMessagePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 0)]
		public byte[] 字节数据;
	}
}
