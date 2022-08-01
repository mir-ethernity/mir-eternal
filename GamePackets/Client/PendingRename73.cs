using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 519, 长度 = 44, 注释 = "申请更改队伍")]
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
