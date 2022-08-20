using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 550, Length = 14, Description = "删除指定邮件")]
	public sealed class 删除指定邮件 : GamePacket
	{
		
		public 删除指定邮件()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 邮件编号;
	}
}
