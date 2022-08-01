using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 187, 长度 = 9, 注释 = "不知道干嘛的, 离开进入安全区触发")]
	public sealed class ReservedPacketZeroTwoPacket : GamePacket
	{
		
		public ReservedPacketZeroTwoPacket()
		{
			
			
		}
	}
}
