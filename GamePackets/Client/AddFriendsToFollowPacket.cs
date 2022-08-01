using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 522, 长度 = 38, 注释 = "AddFriendsToFollowPacket")]
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
