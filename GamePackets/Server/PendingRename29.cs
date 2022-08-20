using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 54, Length = 2, Description = "商店修理全部")]
	public sealed class 商店修理全部 : GamePacket
	{
		
		public 商店修理全部()
		{
			
			
		}
	}
}
