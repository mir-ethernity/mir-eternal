using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 177, Length = 2, Description = "申请离开行会")]
	public sealed class 申请离开行会 : GamePacket
	{
		
		public 申请离开行会()
		{
			
			
		}
	}
}
