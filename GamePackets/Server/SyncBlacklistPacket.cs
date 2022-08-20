using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 68, Length = 0, Description = "SyncBlacklistPacket")]
	public sealed class SyncBlacklistPacket : GamePacket
	{
		
		public SyncBlacklistPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
