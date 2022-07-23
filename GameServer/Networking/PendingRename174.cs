using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 656, 长度 = 6, 注释 = "同步元宝数量")]
	public sealed class 同步元宝数量 : GamePacket
	{
		
		public 同步元宝数量()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 元宝数量;
	}
}
