using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 251, Length = 3, Description = "不知道干嘛的")]
	public sealed class ReservedPacketZeroThreePacket : GamePacket
	{
		
		public ReservedPacketZeroThreePacket()
		{
			
			
		}
	}
}
