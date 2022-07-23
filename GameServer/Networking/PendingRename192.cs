using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 254, 长度 = 3, 注释 = "玩家取下灵石")]
	public sealed class 成功取下灵石 : GamePacket
	{
		
		public 成功取下灵石()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 灵石状态;
	}
}
