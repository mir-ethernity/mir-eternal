using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 258, 长度 = 3, 注释 = "武器升级结果")]
	public sealed class 武器升级结果 : GamePacket
	{
		
		public 武器升级结果()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 升级结果;
	}
}
