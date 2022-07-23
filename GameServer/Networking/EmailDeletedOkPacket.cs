using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 576, 长度 = 14, 注释 = "EmailDeletedOkPacket")]
	public sealed class EmailDeletedOkPacket : GamePacket
	{
		
		public EmailDeletedOkPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 邮件编号;
	}
}
