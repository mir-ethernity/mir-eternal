using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 524, Length = 7, Description = "MobileFriendsGroupPacket(已屏蔽)")]
	public sealed class MobileFriendsGroupPacket : GamePacket
	{
		
		public MobileFriendsGroupPacket()
		{
			
			
		}
	}
}
