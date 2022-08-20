using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 21, Length = 6, Description = "同步角色战力")]
	public sealed class 同步角色战力 : GamePacket
	{
		
		public 同步角色战力()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
