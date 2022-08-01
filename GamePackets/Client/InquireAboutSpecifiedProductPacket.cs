using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 616, 长度 = 6, 注释 = "InquireAboutSpecifiedProductPacket")]
	public sealed class InquireAboutSpecifiedProductPacket : GamePacket
	{
		
		public InquireAboutSpecifiedProductPacket()
		{
			
			
		}
	}
}
