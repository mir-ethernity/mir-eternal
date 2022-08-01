using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 155, 长度 = 11, 注释 = "EndOperationPropsPacket")]
	public sealed class EndOperationPropsPacket : GamePacket
	{
		
		public EndOperationPropsPacket()
		{
			
			
		}
	}
}
