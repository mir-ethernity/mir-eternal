using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 183, Length = 2, Description = "玩家退出登录")]
	public sealed class 玩家退出登录 : GamePacket
	{
		
		public 玩家退出登录()
		{
			
			
		}
	}
}
