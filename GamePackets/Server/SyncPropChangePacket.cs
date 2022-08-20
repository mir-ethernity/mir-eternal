using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 77, Length = 7, Description = "SyncPropChangePacket")]
	public sealed class SyncPropChangePacket : GamePacket
	{
		
		public SyncPropChangePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte StatId;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int Value;
	}
}
