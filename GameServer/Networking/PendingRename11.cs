using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 22, 长度 = 6, 注释 = "进入传送门触发")]
	public sealed class 客户进入法阵 : GamePacket
	{
		
		public 客户进入法阵()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 法阵编号;
	}
}
