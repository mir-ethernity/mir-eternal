using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 530, 长度 = 0, 注释 = "SyncFriendsListPacket")]
	public sealed class SyncFriendsListPacket : GamePacket
	{
		
		public SyncFriendsListPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
