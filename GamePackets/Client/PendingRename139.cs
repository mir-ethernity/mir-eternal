using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 94, Length = 2, Description = "随身特修全部")]
	public sealed class 随身特修全部 : GamePacket
	{
		
		public 随身特修全部()
		{
			
			
		}
	}
}
