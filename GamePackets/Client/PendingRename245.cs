using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 188, Length = 2, Description = "查询问卷调查")]
	public sealed class 查询问卷调查 : GamePacket
	{
		
		public 查询问卷调查()
		{
			
			
		}
	}
}
