using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 610, 长度 = 3, 注释 = "SendGuildNoticePacket")]
	public sealed class SendGuildNoticePacket : GamePacket
	{
		
		public SendGuildNoticePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 提醒类型;
	}
}
