using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 615, Length = 4, Description = "仓库转出应答")]
	public sealed class 仓库转出应答 : GamePacket
	{
		
		public 仓库转出应答()
		{
			
			
		}
	}
}
