using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 569, Length = 2, Description = "查看结盟申请")]
	public sealed class 查看结盟申请 : GamePacket
	{
		
		public 查看结盟申请()
		{
			
			
		}
	}
}
