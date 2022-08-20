using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 11, Length = 2, Description = "ExitCurrentCopyPacket")]
	public sealed class ExitCurrentCopyPacket : GamePacket
	{
		
		public ExitCurrentCopyPacket()
		{
			
			
		}
	}
}
