using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 550, 长度 = 14, 注释 = "删除指定邮件")]
	public sealed class 删除指定邮件 : GamePacket
	{
		
		public 删除指定邮件()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 邮件编号;
	}
}
