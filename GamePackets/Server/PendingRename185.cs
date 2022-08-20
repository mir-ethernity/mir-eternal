using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 600, Length = 6, Description = "脱离行会公告")]
	public sealed class 脱离行会公告 : GamePacket
	{
		
		public 脱离行会公告()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
