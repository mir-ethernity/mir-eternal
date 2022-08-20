using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 51, Length = 2, Description = "SyncRepoListPacket")]
	public sealed class 查询回购列表 : GamePacket
	{
		
		public 查询回购列表()
		{
			
			
		}
	}
}
