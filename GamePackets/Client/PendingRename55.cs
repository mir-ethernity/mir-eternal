using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 542, Length = 2, Description = "离开师门申请")]
	public sealed class 离开师门申请 : GamePacket
	{
		
		public 离开师门申请()
		{
			
			
		}
	}
}
