using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 540, Length = 6, Description = "RejectionApprenticeshipAppPacket")]
	public sealed class RejectionApprenticeshipAppPacket : GamePacket
	{
		
		public RejectionApprenticeshipAppPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
