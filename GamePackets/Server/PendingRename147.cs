using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 338, Length = 0, Description = "同步奖励找回")]
	public sealed class 同步奖励找回 : GamePacket
	{
		
		public 同步奖励找回()
		{
			
			
		}
	}
}
