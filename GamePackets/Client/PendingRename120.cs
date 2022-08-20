using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 527, Length = 6, Description = "添加仇人")]
	public sealed class 玩家添加仇人 : GamePacket
	{
		
		public 玩家添加仇人()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
