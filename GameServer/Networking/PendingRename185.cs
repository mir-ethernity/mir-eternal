using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 600, 长度 = 6, 注释 = "脱离行会公告")]
	public sealed class 脱离行会公告 : GamePacket
	{
		
		public 脱离行会公告()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
