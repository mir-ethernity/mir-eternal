using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 544, Length = 2, Description = "查询师门成员(师徒通用)")]
	public sealed class 查询师门成员 : GamePacket
	{
		
		public 查询师门成员()
		{
			
			
		}
	}
}
