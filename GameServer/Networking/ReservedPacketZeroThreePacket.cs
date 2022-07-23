using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 251, 长度 = 3, 注释 = "不知道干嘛的")]
	public sealed class ReservedPacketZeroThreePacket : GamePacket
	{
		
		public ReservedPacketZeroThreePacket()
		{
			
			
		}
	}
}
