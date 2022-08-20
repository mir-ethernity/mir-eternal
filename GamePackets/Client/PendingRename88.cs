using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 528, Length = 6, Description = "删除仇人")]
	public sealed class 玩家删除仇人 : GamePacket
	{
		
		public 玩家删除仇人()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
