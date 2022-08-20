using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 233, Length = 2, Description = "查询奖励找回")]
	public sealed class 查询奖励找回 : GamePacket
	{
		
		public 查询奖励找回()
		{
			
			
		}
	}
}
