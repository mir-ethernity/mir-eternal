using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 561, Length = 2, Description = "申请解散行会")]
	public sealed class 申请解散行会 : GamePacket
	{
		
		public 申请解散行会()
		{
			
			
		}
	}
}
