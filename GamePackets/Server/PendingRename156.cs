using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 26, 长度 = 6, 注释 = "同步角色行会")]
	public sealed class 同步角色行会 : GamePacket
	{
		
		public 同步角色行会()
		{
			
			
		}
	}
}
