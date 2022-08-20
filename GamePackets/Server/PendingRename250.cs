using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 313, Length = 35, Description = "查询通缉详情")]
	public sealed class 查询通缉详情 : GamePacket
	{
		
		public 查询通缉详情()
		{
			
			
		}
	}
}
