using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 108, Length = 0, Description = "SyncCooldownListPacket")]
	public sealed class SyncCooldownListPacket : GamePacket
	{
		
		public SyncCooldownListPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
