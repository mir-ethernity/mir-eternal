using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 185, 长度 = 0, 注释 = "同步角色变量")]
	public sealed class 同步角色变量 : GamePacket
	{
		
		public 同步角色变量()
		{
			
			
		}
	}
}
