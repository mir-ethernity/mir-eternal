using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 519, 长度 = 10, 注释 = "TeamMembersLeavePacket")]
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
