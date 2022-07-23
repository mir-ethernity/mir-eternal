using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 32, 长度 = 15, 注释 = "不知道干嘛的, 离开进入安全区触发")]
	public sealed class ReservedPacketZeroOnePacket : GamePacket
	{
		
		public ReservedPacketZeroOnePacket()
		{
			
			
		}
	}
}
