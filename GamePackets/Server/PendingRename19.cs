using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 287, Length = 1282, Description = "查询问卷调查")]
	public sealed class 问卷调查应答 : GamePacket
	{
		
		public 问卷调查应答()
		{
			
			
		}
	}
}
