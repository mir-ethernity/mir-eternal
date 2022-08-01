using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 566, 长度 = 6, 注释 = "ExpulsionDivisionDoorPacket")]
	public sealed class ExpulsionDivisionDoorPacket : GamePacket
	{
		
		public ExpulsionDivisionDoorPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
