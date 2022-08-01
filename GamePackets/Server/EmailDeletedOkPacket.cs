using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 576, 长度 = 14, 注释 = "EmailDeletedOkPacket")]
	public sealed class EmailDeletedOkPacket : GamePacket
	{
		
		public EmailDeletedOkPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 邮件编号;
	}
}
