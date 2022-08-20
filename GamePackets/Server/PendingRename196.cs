using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 573, Length = 2, Description = "邮件发送成功")]
	public sealed class 成功发送邮件 : GamePacket
	{
		
		public 成功发送邮件()
		{
			
			
		}
	}
}
