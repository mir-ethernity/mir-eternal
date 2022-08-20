using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 529, Length = 0, Description = "SendChatMessagePacket(公会/队伍/私人)")]
	public sealed class SendSocialMessagePacket : GamePacket
	{
		
		public SendSocialMessagePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 0)]
		public byte[] 字节数据;
	}
}
