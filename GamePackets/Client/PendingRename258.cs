using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 520, Length = 6, Description = "查询队伍信息")]
	public sealed class 查询队伍信息 : GamePacket
	{
		
		public 查询队伍信息()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
