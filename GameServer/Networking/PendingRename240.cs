using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 549, 长度 = 14, 注释 = "查看邮件内容")]
	public sealed class 查看邮件内容 : GamePacket
	{
		
		public 查看邮件内容()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 邮件编号;
	}
}
