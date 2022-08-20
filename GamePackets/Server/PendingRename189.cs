using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 315, Length = 6, Description = "完成通缉榜单")]
	public sealed class 完成通缉榜单 : GamePacket
	{
		
		public 完成通缉榜单()
		{
			
			
		}
	}
}
