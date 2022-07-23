using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 67, 长度 = 93, 注释 = "SyncPlayerData")]
	public sealed class SyncPlayerData : GamePacket
	{
		
		public SyncPlayerData()
		{
			
			
		}
	}
}
