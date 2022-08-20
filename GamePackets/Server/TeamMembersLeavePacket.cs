using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 519, Length = 10, Description = "TeamMembersLeavePacket")]
	public sealed class TeamMembersLeavePacket : GamePacket
	{
		
		public TeamMembersLeavePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 队伍编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 对象编号;
	}
}
