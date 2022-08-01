using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 628, 长度 = 11, 注释 = "取消建筑升级")]
	public sealed class 取消建筑升级 : GamePacket
	{
		
		public 取消建筑升级()
		{
			
			
		}
	}
}
