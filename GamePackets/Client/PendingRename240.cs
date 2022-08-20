using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 549, Length = 14, Description = "查看邮件内容")]
	public sealed class 查看邮件内容 : GamePacket
	{
		
		public 查看邮件内容()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 邮件编号;
	}
}
