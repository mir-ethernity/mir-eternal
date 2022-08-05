using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 622, 长度 = 27, 注释 = "加入行会公告")]
	public sealed class 加入行会公告 : GamePacket
	{
		
		public 加入行会公告()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 25)]
		public string GuildName;
	}
}
