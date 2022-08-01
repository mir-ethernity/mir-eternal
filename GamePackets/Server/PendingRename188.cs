using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 613, 长度 = 0, 注释 = "GuildWarehouseRefreshPacket")]
	public sealed class 刷新行会仓库 : GamePacket
	{
		
		public 刷新行会仓库()
		{
			
			
		}
	}
}
