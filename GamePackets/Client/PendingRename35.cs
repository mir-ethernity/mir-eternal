using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 246, Length = 10, Description = "开始战场演武")]
	public sealed class 开始战场演武 : GamePacket
	{
		
		public 开始战场演武()
		{
			
			
		}
	}
}
