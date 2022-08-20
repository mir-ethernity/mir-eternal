using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 133, Length = 0, Description = "SyncRepoListPacket")]
	public sealed class SyncRepoListPacket : GamePacket
	{
		
		public SyncRepoListPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
