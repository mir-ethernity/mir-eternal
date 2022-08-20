using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 627, Length = 11, Description = "更新建筑升级")]
	public sealed class 更新建筑升级 : GamePacket
	{
		
		public 更新建筑升级()
		{
			
			
		}
	}
}
