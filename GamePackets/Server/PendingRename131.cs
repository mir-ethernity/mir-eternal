using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 538, Length = 6, Description = "删除仇人")]
	public sealed class 玩家移除仇人 : GamePacket
	{
		
		public 玩家移除仇人()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
