using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 665, Length = 34, Description = "攻城获胜公告")]
	public sealed class 攻城获胜公告 : GamePacket
	{
		
		public 攻城获胜公告()
		{
			
			
		}
	}
}
