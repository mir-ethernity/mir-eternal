using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 147, 长度 = 6, 注释 = "玩家申请交易")]
	public sealed class 玩家申请交易 : GamePacket
	{
		
		public 玩家申请交易()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
