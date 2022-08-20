using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 543, Length = 6, Description = "AppForExpulsionPacket")]
	public sealed class AppForExpulsionPacket : GamePacket
	{
		
		public AppForExpulsionPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
