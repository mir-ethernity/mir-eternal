using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 522, 长度 = 38, 注释 = "AddFriendsToFollowPacket")]
	public sealed class AddFriendsToFollowPacket : GamePacket
	{
		
		public AddFriendsToFollowPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 32)]
		public string 对象名字;
	}
}
