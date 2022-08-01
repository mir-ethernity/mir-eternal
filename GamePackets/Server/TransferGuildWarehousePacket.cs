using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 614, 长度 = 0, 注释 = "GuildWarehouseTransferPacket")]
	public sealed class TransferGuildWarehousePacket : GamePacket
	{
		
		public TransferGuildWarehousePacket()
		{
			
			
		}
	}
}
