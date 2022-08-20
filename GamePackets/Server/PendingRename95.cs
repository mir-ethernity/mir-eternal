using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 516, Length = 0, Description = "玩家加入队伍")]
	public sealed class 玩家加入队伍 : GamePacket
	{
		
		public 玩家加入队伍()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
