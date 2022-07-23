using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 626, 长度 = 15, 注释 = "升级建筑公告")]
	public sealed class 升级建筑公告 : GamePacket
	{
		
		public 升级建筑公告()
		{
			
			
		}
	}
}
