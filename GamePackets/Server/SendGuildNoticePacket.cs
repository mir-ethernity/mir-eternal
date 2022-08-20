using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 610, Length = 3, Description = "SendGuildNoticePacket")]
	public sealed class SendGuildNoticePacket : GamePacket
	{
		
		public SendGuildNoticePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 提醒类型;
	}
}
