using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 516, 长度 = 0, 注释 = "玩家加入队伍")]
	public sealed class 玩家加入队伍 : GamePacket
	{
		
		public 玩家加入队伍()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
