using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 517, Length = 6, Description = "申请离开队伍")]
	public sealed class 申请离开队伍 : GamePacket
	{
		
		public 申请离开队伍()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
