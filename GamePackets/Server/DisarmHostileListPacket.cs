using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 640, Length = 10, Description = "DisarmHostileListPacket")]
	public sealed class DisarmHostileListPacket : GamePacket
	{
		
		public DisarmHostileListPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 申请类型;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 行会编号;
	}
}
