using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 566, Length = 6, Description = "ExpulsionDivisionDoorPacket")]
	public sealed class ExpulsionDivisionDoorPacket : GamePacket
	{
		
		public ExpulsionDivisionDoorPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
