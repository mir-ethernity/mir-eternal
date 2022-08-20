using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 537, Length = 6, Description = "添加仇人")]
	public sealed class 玩家标记仇人 : GamePacket
	{
		
		public 玩家标记仇人()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
