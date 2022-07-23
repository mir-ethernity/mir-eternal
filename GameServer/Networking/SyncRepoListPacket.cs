using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 133, 长度 = 0, 注释 = "SyncRepoListPacket")]
	public sealed class SyncRepoListPacket : GamePacket
	{
		
		public SyncRepoListPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节描述;
	}
}
