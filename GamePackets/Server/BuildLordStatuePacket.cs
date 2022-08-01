using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 664, 长度 = 226, 注释 = "BuildLordStatuePacket")]
	public sealed class BuildLordStatuePacket : GamePacket
	{
		
		public BuildLordStatuePacket()
		{
			
			
		}
	}
}
