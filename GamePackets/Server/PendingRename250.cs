using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 313, 长度 = 35, 注释 = "查询通缉详情")]
	public sealed class 查询通缉详情 : GamePacket
	{
		
		public 查询通缉详情()
		{
			
			
		}
	}
}
