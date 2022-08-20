using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 112, Length = 6, Description = "离开战斗姿态")]
	public sealed class 离开战斗姿态 : GamePacket
	{
		
		public 离开战斗姿态()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
