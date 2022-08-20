using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 24, Length = 0, Description = "SyncTitleInfoPacket")]
	public sealed class SyncTitleInfoPacket : GamePacket
	{
		
		public SyncTitleInfoPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
