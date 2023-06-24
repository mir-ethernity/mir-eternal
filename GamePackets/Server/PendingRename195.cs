using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 578, Length = 6, Description = "提取附件成功")]
	public sealed class 成功提取附件 : GamePacket
	{
		
		public 成功提取附件()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 邮件编号;
	}
}
