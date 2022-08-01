using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 251, 长度 = 3, 注释 = "不知道干嘛的")]
	public sealed class ReservedPacketZeroThreePacket : GamePacket
	{
		
		public ReservedPacketZeroThreePacket()
		{
			
			
		}
	}
}
