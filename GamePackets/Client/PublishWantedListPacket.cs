using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 211, 长度 = 50, 注释 = "PublishWantedListPacket")]
	public sealed class PublishWantedListPacket : GamePacket
	{
		
		public PublishWantedListPacket()
		{
			
			
		}
	}
}
