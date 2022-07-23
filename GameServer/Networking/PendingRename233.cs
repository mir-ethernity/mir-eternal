using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 599, 长度 = 7, 注释 = "变更职位公告")]
	public sealed class 变更职位公告 : GamePacket
	{
		
		public 变更职位公告()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 对象职位;
	}
}
