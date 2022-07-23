using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 627, 长度 = 11, 注释 = "更新建筑升级")]
	public sealed class 更新建筑升级 : GamePacket
	{
		
		public 更新建筑升级()
		{
			
			
		}
	}
}
