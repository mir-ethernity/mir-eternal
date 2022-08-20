using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 538, Length = 7, Description = "玩家申请收徒")]
	public sealed class 玩家申请收徒 : GamePacket
	{
		
		public 玩家申请收徒()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int 对象编号;
	}
}
