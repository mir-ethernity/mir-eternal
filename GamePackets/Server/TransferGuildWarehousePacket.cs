using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 614, Length = 0, Description = "GuildWarehouseTransferPacket")]
	public sealed class TransferGuildWarehousePacket : GamePacket
	{
		
		public TransferGuildWarehousePacket()
		{
			
			
		}
	}
}
