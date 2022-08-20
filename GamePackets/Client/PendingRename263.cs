using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 546, Length = 2, Description = "提交出师申请")]
	public sealed class 提交出师申请 : GamePacket
	{
		
		public 提交出师申请()
		{
			
			
		}
	}
}
