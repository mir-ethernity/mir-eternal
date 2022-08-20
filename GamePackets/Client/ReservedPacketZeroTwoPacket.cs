using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 187, Length = 9, Description = "不知道干嘛的, 离开进入安全区触发")]
	public sealed class ReservedPacketZeroTwoPacket : GamePacket
	{
		
		public ReservedPacketZeroTwoPacket()
		{
			
			
		}
	}
}
