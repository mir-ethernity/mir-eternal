using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 517, 长度 = 6, 注释 = "玩家离开队伍")]
	public sealed class 玩家离开队伍 : GamePacket
	{
		
		public 玩家离开队伍()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 队伍编号;
	}
}
