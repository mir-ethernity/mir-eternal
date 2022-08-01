using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 131, 长度 = 0, 注释 = "SendChatMessagePacket(附近|广播|传音)")]
	public sealed class SendChatMessagePacket : GamePacket
	{
		
		public SendChatMessagePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 0)]
		public byte[] 字节数据;
	}
}
