using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 536, Length = 6, Description = "RefusedApplyApprenticeshipPacket")]
	public sealed class RefusedApplyApprenticeshipPacket : GamePacket
	{
		
		public RefusedApplyApprenticeshipPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
