using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 551, Length = 14, Description = "提取邮件附件")]
	public sealed class 提取邮件附件 : GamePacket
	{
		
		public 提取邮件附件()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 邮件编号;
	}
}
