using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 560, Length = 6, Description = "RejectionTipsPacket")]
	public sealed class RejectionTipsPacket : GamePacket
	{
		
		public RejectionTipsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
