using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 566, 长度 = 6, 注释 = "ExpulsionDivisionDoorPacket")]
	public sealed class ExpulsionDivisionDoorPacket : GamePacket
	{
		
		public ExpulsionDivisionDoorPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
