using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 135, 长度 = 28, 注释 = "CreateNewFriendGroupPacket(已屏蔽)")]
	public sealed class CreateNewFriendGroupPacket : GamePacket
	{
		
		public CreateNewFriendGroupPacket()
		{
			
			
		}
	}
}
