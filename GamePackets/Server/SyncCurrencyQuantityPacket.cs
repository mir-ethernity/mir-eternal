using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 148, Length = 0, Description = "SyncCurrencyQuantityPacket")]
	public sealed class SyncCurrencyQuantityPacket : GamePacket
	{
		
		public SyncCurrencyQuantityPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 5, Length = 0)]
		public byte[] 字节描述;
	}
}
