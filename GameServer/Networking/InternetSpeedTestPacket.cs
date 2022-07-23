using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 45, 长度 = 6, 注释 = "同步游戏ping")]
	public sealed class InternetSpeedTestPacket : GamePacket
	{
		
		public InternetSpeedTestPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 当前时间;
	}
}
