using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 622, Length = 27, Description = "加入行会公告")]
	public sealed class 加入行会公告 : GamePacket
	{
		
		public 加入行会公告()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 25)]
		public string GuildName;
	}
}
