using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 602, 长度 = 10, 注释 = "会长传位公告")]
	public sealed class 会长传位公告 : GamePacket
	{
		
		public 会长传位公告()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 当前编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 传位编号;
	}
}
