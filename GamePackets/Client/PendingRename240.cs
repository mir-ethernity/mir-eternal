using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 549, 长度 = 14, 注释 = "查看邮件内容")]
	public sealed class 查看邮件内容 : GamePacket
	{
		
		public 查看邮件内容()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 邮件编号;
	}
}
