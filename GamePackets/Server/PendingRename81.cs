using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 602, Length = 10, Description = "会长传位公告")]
	public sealed class 会长传位公告 : GamePacket
	{
		
		public 会长传位公告()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 当前编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 传位编号;
	}
}
