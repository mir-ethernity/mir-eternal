using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 682, 长度 = 326, 注释 = "MartialArtsChallengeListPacket")]
	public sealed class MartialArtsChallengeListPacket : GamePacket
	{
		
		public MartialArtsChallengeListPacket()
		{
			
			
		}
	}
}
