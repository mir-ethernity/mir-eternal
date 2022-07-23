using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 616, 长度 = 6, 注释 = "InquireAboutSpecifiedProductPacket")]
	public sealed class InquireAboutSpecifiedProductPacket : GamePacket
	{
		
		public InquireAboutSpecifiedProductPacket()
		{
			
			
		}
	}
}
