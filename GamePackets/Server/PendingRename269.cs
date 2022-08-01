using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 611, 长度 = 5, 注释 = "更改存取权限")]
	public sealed class 更改存取权限 : GamePacket
	{
		
		public 更改存取权限()
		{
			
			
		}
	}
}
