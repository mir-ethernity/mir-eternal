using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 577, Length = 6, Description = "未读邮件提醒")]
	public sealed class 未读邮件提醒 : GamePacket
	{
		
		public 未读邮件提醒()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 邮件数量;
	}
}
