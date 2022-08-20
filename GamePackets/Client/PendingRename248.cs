using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 160, Length = 2, Description = "查询师门奖励(师徒通用)")]
	public sealed class 查询师门奖励 : GamePacket
	{
		
		public 查询师门奖励()
		{
			
			
		}
	}
}
