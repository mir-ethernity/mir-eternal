using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 160, 长度 = 7, 注释 = "升级摊位外观")]
	public sealed class 升级摊位外观 : GamePacket
	{
		
		public 升级摊位外观()
		{
			
			
		}
	}
}
