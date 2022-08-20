using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 131, Length = 0, Description = "SendChatMessagePacket(附近|广播|传音)")]
	public sealed class SendChatMessagePacket : GamePacket
	{
		
		public SendChatMessagePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 0)]
		public byte[] 字节数据;
	}
}
