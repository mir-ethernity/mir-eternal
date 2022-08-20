using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 17, Length = 0, Description = "SyncBackpackInfoPacket")]
	public sealed class SyncBackpackInfoPacket : GamePacket
	{
		
		public SyncBackpackInfoPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 6, Length = 0)]
		public byte[] 物品描述;
	}
}
