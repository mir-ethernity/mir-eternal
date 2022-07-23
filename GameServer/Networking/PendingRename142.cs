using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 673, 长度 = 0, 注释 = "同步珍宝数量")]
	public sealed class 同步珍宝数量 : GamePacket
	{
		
		public 同步珍宝数量()
		{
			
			
		}
	}
}
