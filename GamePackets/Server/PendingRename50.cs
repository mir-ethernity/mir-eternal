using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 628, Length = 11, Description = "取消建筑升级")]
	public sealed class 取消建筑升级 : GamePacket
	{
		
		public 取消建筑升级()
		{
			
			
		}
	}
}
