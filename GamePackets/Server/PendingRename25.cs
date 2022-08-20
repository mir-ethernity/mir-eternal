using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 609, Length = 7, Description = "删除外交公告")]
	public sealed class 删除外交公告 : GamePacket
	{
		
		public 删除外交公告()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 外交类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int 行会编号;
	}
}
