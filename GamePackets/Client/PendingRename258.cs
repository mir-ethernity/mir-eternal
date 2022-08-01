using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 520, 长度 = 6, 注释 = "查询队伍信息")]
	public sealed class 查询队伍信息 : GamePacket
	{
		
		public 查询队伍信息()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
