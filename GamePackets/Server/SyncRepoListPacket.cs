using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 133, 长度 = 0, 注释 = "SyncRepoListPacket")]
	public sealed class SyncRepoListPacket : GamePacket
	{
		
		public SyncRepoListPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
