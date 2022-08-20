using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 522, Length = 38, Description = "AddFriendsToFollowPacket")]
	public sealed class AddFriendsToFollowPacket : GamePacket
	{
		
		public AddFriendsToFollowPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 32)]
		public string 对象名字;
	}
}
