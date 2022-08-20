using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 664, Length = 226, Description = "BuildLordStatuePacket")]
	public sealed class BuildLordStatuePacket : GamePacket
	{
		
		public BuildLordStatuePacket()
		{
			
			
		}
	}
}
