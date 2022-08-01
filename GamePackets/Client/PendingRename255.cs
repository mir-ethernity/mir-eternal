using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 140, 长度 = 2, 注释 = "查询附近队伍")]
	public sealed class 查询附近队伍 : GamePacket
	{
		
		public 查询附近队伍()
		{
			
			
		}
	}
}
