using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 662, Length = 10, Description = "同步占领行会")]
	public sealed class 同步占领行会 : GamePacket
	{
		
		public 同步占领行会()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 行会编号;
	}
}
