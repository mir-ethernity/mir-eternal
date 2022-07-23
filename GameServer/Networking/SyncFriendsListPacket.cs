using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 530, 长度 = 0, 注释 = "SyncFriendsListPacket")]
	public sealed class SyncFriendsListPacket : GamePacket
	{
		
		public SyncFriendsListPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节描述;
	}
}
