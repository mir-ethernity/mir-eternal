using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 519, Length = 44, Description = "申请更改队伍")]
	public sealed class 申请更改队伍 : GamePacket
	{
		
		public 申请更改队伍()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 成员上限;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 4)]
		public int 队长编号;
	}
}
