using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 257, 长度 = 2, 注释 = "取回升级武器")]
	public sealed class 取回升级武器 : GamePacket
	{
		
		public 取回升级武器()
		{
			
			
		}
	}
}
