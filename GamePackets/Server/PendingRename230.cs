using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 104, Length = 10, Description = "体力变动飘字")]
	public sealed class 体力变动飘字 : GamePacket
	{
		
		public 体力变动飘字()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 血量变化;
	}
}
