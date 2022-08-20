using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 57, Length = 4, Description = "玩家扩展背包")]
	public sealed class 玩家扩展背包 : GamePacket
	{
		
		public 玩家扩展背包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 背包类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 扩展大小;
	}
}
