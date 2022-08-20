using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 613, Length = 0, Description = "GuildWarehouseRefreshPacket")]
	public sealed class 刷新行会仓库 : GamePacket
	{
		
		public 刷新行会仓库()
		{
			
			
		}
	}
}
