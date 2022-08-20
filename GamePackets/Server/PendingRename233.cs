using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 599, Length = 7, Description = "变更职位公告")]
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
