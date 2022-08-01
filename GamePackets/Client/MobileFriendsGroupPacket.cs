using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 524, 长度 = 7, 注释 = "MobileFriendsGroupPacket(已屏蔽)")]
	public sealed class MobileFriendsGroupPacket : GamePacket
	{
		
		public MobileFriendsGroupPacket()
		{
			
			
		}
	}
}
