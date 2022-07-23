using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 11, 长度 = 2, 注释 = "ExitCurrentCopyPacket")]
	public sealed class ExitCurrentCopyPacket : GamePacket
	{
		
		public ExitCurrentCopyPacket()
		{
			
			
		}
	}
}
