using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 565, Length = 6, Description = "ExpulsionDoorAnswerPacket")]
	public sealed class ExpulsionDoorAnswerPacket : GamePacket
	{
		
		public ExpulsionDoorAnswerPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
