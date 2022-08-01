using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 599, 长度 = 7, 注释 = "变更职位公告")]
	public sealed class 变更职位公告 : GamePacket
	{
		
		public 变更职位公告()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 对象职位;
	}
}
