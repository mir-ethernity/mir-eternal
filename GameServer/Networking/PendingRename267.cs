using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 158, 长度 = 3, 注释 = "更改收徒推送")]
	public sealed class 更改收徒推送 : GamePacket
	{
		
		public 更改收徒推送()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public bool 收徒推送;
	}
}
