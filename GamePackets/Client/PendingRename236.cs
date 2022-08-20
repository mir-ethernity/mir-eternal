using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 557, Length = 2, Description = "查看申请列表")]
	public sealed class 查看申请列表 : GamePacket
	{
		
		public 查看申请列表()
		{
			
			
		}
	}
}
