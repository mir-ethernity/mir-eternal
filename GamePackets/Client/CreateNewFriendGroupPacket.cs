using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 135, Length = 28, Description = "CreateNewFriendGroupPacket(已屏蔽)")]
	public sealed class CreateNewFriendGroupPacket : GamePacket
	{
		
		public CreateNewFriendGroupPacket()
		{
			
			
		}
	}
}
