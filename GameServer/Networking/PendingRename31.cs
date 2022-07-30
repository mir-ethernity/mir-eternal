using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 577, 长度 = 6, 注释 = "未读邮件提醒")]
	public sealed class 未读邮件提醒 : GamePacket
	{
		
		public 未读邮件提醒()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 邮件数量;
	}
}
