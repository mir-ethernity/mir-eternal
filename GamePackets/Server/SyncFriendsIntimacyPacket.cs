using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 539, 长度 = 10, 注释 = "同步亲密度")]
	public sealed class SyncFriendsIntimacyPacket : GamePacket
	{
		
		public SyncFriendsIntimacyPacket()
		{
			
			
		}
	}
}
