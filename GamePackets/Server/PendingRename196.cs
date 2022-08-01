using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 573, 长度 = 2, 注释 = "邮件发送成功")]
	public sealed class 成功发送邮件 : GamePacket
	{
		
		public 成功发送邮件()
		{
			
			
		}
	}
}
