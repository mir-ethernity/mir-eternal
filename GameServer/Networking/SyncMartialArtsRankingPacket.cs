using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 687, 长度 = 499, 注释 = "跨服武道排名")]
	public sealed class SyncMartialArtsRankingPacket : GamePacket
	{
		
		public SyncMartialArtsRankingPacket()
		{
			
			
		}
	}
}
