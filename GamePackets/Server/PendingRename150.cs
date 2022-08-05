using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 61, 长度 = 0, 注释 = "同步角色列表, 适用于角色位移时同步视野")]
	public sealed class 同步角色列表 : GamePacket
	{

		
		public 同步角色列表()
		{
			
			
		}
	}
}
