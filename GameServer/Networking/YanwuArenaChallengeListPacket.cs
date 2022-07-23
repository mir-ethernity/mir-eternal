using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 683, 长度 = 558, 注释 = "YanwuArenaChallengeListPacket")]
	public sealed class YanwuArenaChallengeListPacket : GamePacket
	{
		
		public YanwuArenaChallengeListPacket()
		{
			
			
		}
	}
}
