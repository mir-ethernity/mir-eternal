using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 315, 长度 = 6, 注释 = "完成通缉榜单")]
	public sealed class 完成通缉榜单 : GamePacket
	{
		
		public 完成通缉榜单()
		{
			
			
		}
	}
}
